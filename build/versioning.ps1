#========================================
# Version Helper functions
#========================================
$delim = "."



function Get-Dll-Version($dll_file) {
	$resolved = Resolve-Path $dll_file
	Write-Progress "Obtaining version from $dll_file"
    Write-Debug " $resolved "
    if(!(Test-Path $resolved)) {
        throw "Cannot retrive assembly version because file '$resolved' does not exists."
    }
    $version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($resolved).ProductVersion
    #$version = [System.Reflection.Assembly]::LoadFrom($resolved).GetName().Version.ToString()
    Write-Host $version
    return $version
}




function Get-Incremented-Version-Numbers($version,$portion) {
    $version_array =  [string[]] $version.Split('.')
    $version_length = $version_array.Length
	Write-Progress "Updating from $version to"
    switch ($portion) 
    { 
        "major" {
            if ($version_length -ge 1) {
                #$version_array[0] += 1
                $version_array[0] = Increment-Version $version_array[0]
            } else {
                throw
            }
        } 
        "minor" {
            if ($version_length -ge 2) {
                #$version_array[1] += 1
                $version_array[1] = Increment-Version $version_array[1]
            } else {
                throw
            }
        } 
        "build" {
            if ($version_length -ge 3) {
                #$version_array[2] += 1
                $version_array[2] = Increment-Version $version_array[2]
            } else {
                throw
            }
        } 
        "revision" {            
            if ($version_length -ge 3) {
                #$version_array[3] += 1
                $version_array[3] = Increment-Version $version_array[3]
            } else {
                throw
            }
        } 
        default { throw "The argument `$portion ($portion) is not valid."}
    }
    $new_version = $version_array -join "."
    Write-Success "$new_version`n"
    return $new_version
}

function Increment-Version($portion){
    $version_array =  ([string]$portion).Split('-')
    $version_array[0] = ($version_array[0] -as [int]) + 1
    return $version_array -join "-"
}


function Set-Assembly-Version([string[]]$assembly_files, [string] $version) {
    if ($assembly_files.Count -eq 0) {
        return
    }
    Write-Progress "Updating:`n"
    $assembly_version_types = @(@{Label = "Version"; RemoveStrings = $true}, @{Label = "InformationalVersion"; RemoveStrings = $false},  @{Label = "FileVersion"; RemoveStrings = $true})
    $assemblyPattern = "(?<version>[0-9]+(\.([0-9]+(\-[a-zA-Z0-9]*)?|\*)){1,3})"
    foreach($file in $assembly_files) {

        Write-Host "`n`n      $file`n"

        $replaced = $false
        [string] $contents = [System.IO.File]::ReadAllText($file)
        foreach($version_type in $assembly_version_types) {
            #AssemblyVersion\("([0-9]+(\.([0-9]+(\-[a-zA-Z0-9]*)?|\*)){1,3})"\)
            $pattern = [string]::Format("Assembly{0}\(`"{1}`"\)",$version_type.Label,$assemblyPattern)
            $match = [Regex]::Match($contents,$pattern)
            if ($match.Success) {
                [string] $old = $match.Groups["version"]
                $new_version = Copy-Version $version $old $version_type.RemoveStrings
                if($new_version -eq $old) {
                    Write-Debug "$version_type is the same"
                } else {
                    $replacement = [string]::Format("Assembly{0}(`"{1}`")",$version_type.Label, $new_version)
                    $contents = [Regex]::Replace($contents,$pattern,$replacement)
                    $replaced = $true
                    Write-Version-Update $version_type.Label $old $new_version
            }
        }
        }
        if ($replaced) {
            [System.IO.File]::WriteAllText($file, $contents)
            Write-Debug "Saved!"
        }

        }
    return
}
        



function Split-Version([string] $version) {
    return $version.split($delim)
}


function Join-Version([string[]] $array) {
    return $array -join $delim
}


function Copy-Version([string] $version1, [string] $version2, [boolean] $removeStrings) {
    $copied = $false
    $source_array = Split-Version $version1
    $destination_array = Split-Version $version2
    $upperLimit = [Math]::Min($source_array.Length, $destination_array.Length) - 1
    for($i=0;$i -le $upperLimit; $i++) {
        if($destination_array[$i] -ne "*" -and $destination_array[$i] -ne $source_array[$i]) {
            $this = ($source_array[$i] -as [string])
            $term = [string[]]$this.Split("-")
            if ($term.Length -gt 1 -and $removeStrings -eq $true) {
                $destination_array[$i] = $term[0]
            } else {
            $destination_array[$i] = $source_array[$i]
                }
            $copied = $true
            }
        }
    if ($copied) {
        return Join-Version $destination_array
        }
    return $version1
}

        
function Write-Version-Update([string] $version_type, [string] $old_version, [string] $new_version) {
    Write-Host "      Updated $version_type from $old_version to" -NoNewline
    Write-Success $($new_version)
}
#========================================
# /Version Helper functions
#========================================
