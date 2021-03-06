#========================================
# Nuget functions
#========================================

function Create-Nupkg ([string]$nu_spec_or_trans_file_path, [string]$nupkg_path, [string]$configuration, [bool]$pack_source_code_only, [string]$version) {
    $params= @{}
    $params.base_directory = [System.IO.Path]::GetDirectoryName($nu_spec_or_trans_file_path)
    $params.nuspec_file_name_wo_ext = [System.IO.Path]::GetFileNameWithoutExtension($nu_spec_or_trans_file_path)
    $params.extension = [System.IO.Path]::GetExtension($nu_spec_or_trans_file_path)
    $params.csproj_file_name = "$($params.nuspec_file_name_wo_ext).csproj"
    $params.csproj_file_path = "$($params.base_directory)\$($params.csproj_file_name)"
    $params.nuspec_file_name = "$($params.nuspec_file_name_wo_ext).nuspec"
    $params.nuspec_file_path = "$($params.base_directory)\$($params.nuspec_file_name)"
    $params.nupkg_file_path = $nupkg_path
    $params.nuget_options = @("-IncludeReferencedProjects")

    if ($params.extension -eq ".nutrans") {
        Write-Warning "     Packing using shared template"
    	$params.nutrans_file_name = "$($params.nuspec_file_name_wo_ext).nutrans"
        $params.nutrans_file_path = "$($params.base_directory)\$($params.nutrans_file_name)"
        Create-Nuspec-From-Nutrans $params.nutrans_file_path $params.nuspec_file_path
    } else {
        Write-Warning "     Packing NOT using shared template"
    }
    Write-HashTable-Debug $params "Nuspec variables"
    if($pack_source_code_only) {
        Include-Files-Nuspec $params.nuspec_file_path
    }

    if (Test-Path $params.csproj_file_path) {
        $params.nuspec_file_name = $params.csproj_file_name
        $params.nuspec_file_path =  $params.csproj_file_path
        if(!$pack_source_code_only) {
            #$params.nuget_options += "-Sym"
        }
        $params.nuget_options += "-Properties Configuration=$configuration"
    }

	Write-Host "`n"
    Write-Progress "Creating nupkg from '$($params.nuspec_file_path)'`n"
    $command = "& $($tools.nuget) pack $($params.nuspec_file_path) $($params.nuget_options -join ' ') -Version $version -OutputDirectory $($params.nupkg_file_path)"
    Exec { Invoke-Expression $command } | Out-Null
	Write-Host "`n"
	Write-Success "  Packing Succeeded!"
	return "$($params.nupkg_file_path)\$([System.IO.Path]::GetFileNameWithoutExtension($params.nuspec_file_path)).$($version).nupkg"
}

function Push-Nupkg ($nuget_package_file_path) {
    Write-Debug "File to push $nuget_package_file_path"

    $vars1 = ReadVariables $keyfile
    Write-HashTable-Debug($vars1)

    $filename = [System.IO.Path]::GetFileName($nuget_package_file_path)
    Write-Progress "About to push '$filename' to Nuget gallery`n"
    Exec { & $tools.nuget push $nuget_package_file_path -ApiKey "$($vars1.Username)" -Source $($vars1.Feed) }
	Write-Host "`n"
	Write-Success "  Pushed!"
	Write-Host "`n"
    return
}

function Include-Files-Nuspec($nuspec_file_path) {
    $xmlDoc = [System.Xml.XmlDocument](get-content $nuspec_file_path -Encoding UTF8)
	Write-Host "`n`n    Copying source files:"
    Get-ChildItem "$($conf.project_dir)\*.cs" | foreach {
		$params = @{}
        $params.source_file = $($_.Name)
		$params.source_file_path = $($_.FullName)
		$params.destination_file = "$($params.source_file).pp"
		$params.destination_file_path = "$($conf.project_release_dir)\$($params.destination_file)"
		Write-HashTable-Debug $params "Copy source code variables"
        Write-Progress "Copying $($params.source_file) as $($params.destination_file)"
        Copy-Item -Path $($params.source_file_path) -Destination $($params.destination_file_path)
		Write-Success
    } | Out-Null
		
		
	Write-Host "`n`n    Adding source files to nuspec:"
    $files = $xmlDoc.package.files

    if (-not $files) {
		Write-Host "    " -NoNewline
        Write-Warning "<files> node does not exists. It will be created."
        $files = $xmlDoc.CreateElement('files')
        $xmlDoc.package.AppendChild($files) | Out-Null
    } else {
        [void]$files.RemoveAll()
    }

    $current = "$($conf.project_release_dir)\"
    $relative = RelativePath $current "$($conf.project_dir)\"
	$target = 'content\_extensions'
    Get-ChildItem "$($current)\*.cs.pp" | foreach { 
        $file_to_include = "$($relative)$($_.Name)"
        Write-Progress "Adding Source '$file_to_include' to target '$target'"
        $file = $xmlDoc.CreateElement('file')
        $file.SetAttribute('src',$file_to_include)
        $file.SetAttribute('target',$target)
        $files.AppendChild($file)
		Write-Success
    } | Out-Null
    $xmlDoc.Save($nuspec_file_path)
    return
}



function Create-Nuspec-From-Nutrans ($nutrans_file_path,$nuspec_file_path) {
    Write-Progress "Creating nuspec $nuspec_file_path from $nutrans_file_path"
    Exec { msbuild $tools.transform /p:Transform=$nutrans_file_path /p:Destination=$nuspec_file_path /v:minimal /nologo }
	Write-Success
	return
}



function Get-Nuspec-Metadata-Node($xml) {
    return $xml.SelectSingleNode("//*[local-name()='metadata']")
}

function Get-Nuspec-Version-Node($xml) {
    $metadata = Get-Nuspec-Metadata-Node $xml
    return $metadata.SelectSingleNode("//*[local-name()='version']")
}

function Get-Nuspec-Version($nuspec_file_path,$default) {
    $xml = [System.Xml.XmlDocument](get-content $nuspec_file_path -Encoding UTF8)
    $node = Get-Nuspec-Version-Node $xml
    if ($node) { 
        $default = $node.InnerText
    }
    return $default
}

function Update-Nuspec-Version($nuspec_file_path, $version) {
    $xml = [System.Xml.XmlDocument](get-content $nuspec_file_path -Encoding UTF8)
    $metadata = Get-Nuspec-Metadata-Node $xml
    $node = Get-Nuspec-Version-Node $xml
	Write-Host "`n`n    Configuring version in nuspec"
	Write-Progress "Version set to $version"
    if ($node) {
        $node.InnerText = $version
    } else {
        $node = $xml.CreateElement('version')
        $node.InnerText = $version
        $metadata.AppendChild($node)
    }
	Write-Success
    $xml.Save($nuspec_file_path)
	return
}
#========================================
# /Nuget functions
#========================================
