#========================================
# Helper functions
#========================================

function GetProjects($file) {
    $projects = @()
    Get-Content $file |
      Select-String 'Project\(' |
        ForEach-Object {
          $projectParts = $_ -Split '[,=]' | ForEach-Object { $_.Trim('[ "{}]') };
          $name = $projectParts[1]
          $file = "$($conf.source_dir)\$($projectParts[2])"
          $path = [System.IO.Path]::GetDirectoryName($file)
          $bin = "$($path)\bin\$($conf.configuration)"
          $dll = "$($bin)\$($Name).dll"
          $proj = New-Object PSObject -Property @{
            Name = $name;
            File = $file;
            Path = $path;
            Bin = $bin
            Dll = $dll
            Version = Get-Dll-Version($dll)
          }
          $projects += $proj
        }
        return $projects
}



function ReadVariables($file) {
    $vars = @{}
    Get-Content $file | Foreach-Object {
       $var = $_.Split('=')
       $vars.Add($var[0],$var[1])
    }
    return $vars
}

function Clean-Directory ($dir) {
    Write-Progress "Cleaning $dir"
    if (Test-Path $dir) { 
        Remove-Item $dir -Force -Recurse -ErrorAction SilentlyContinue | Out-Null
    }
    #New-Item $dir -ItemType Directory | Out-Null
	Write-Success "Cleaned"
    return
}


function Write-HashTable-Debug ($hash, [string]$title) {
	$output = "`n" + (Header $title)
	$output += ($hash.GetEnumerator() | Sort-Object -Property Name  | Format-Table -Wrap -AutoSize| Out-String )
    Write-Debug $output
	return
}

function Header ([string]$title) {
	$output = ""
	if ($title) {
		$length = $title.Length * 1.5
		$output += "`n$('-' * $length)`n $title`n$('-' * $length)`n"
	}
	return $output
}

function Write-Header ([string]$title) {
	Write-Host (Header $title) -foregroundcolor DarkGray
	return
}

function Write-Progress ([string]$title) {
	Write-Host "  - $title" -nonewline -ForegroundColor Gray
	return
}

function Write-Success ([string]$title) {
	$output = @{$true="OK";$false=$title}[[string]::IsNullOrWhiteSpace($title)]
	Write-Host "  $output" -ForegroundColor Green
	return
}

function RelativePath
{
    param
    (
        [string]$path = $(throw "Missing: path"),
        [string]$basepath = $(throw "Missing: base path")
    )
    
    return [system.io.path]::GetFullPath($path).SubString([system.io.path]::GetFullPath($basepath).Length)
}   

function Set-Source-Path ([string]$source_path) {
    if([string]::IsNullOrEmpty($source_path)) {
        $convention = @(".\..\Source", ".\..\src")
        foreach($location in $convention) {
            if(Test-Path($location)) { 
                $source_path = $location
                break
            }
        }
        if ([string]::IsNullOrEmpty($source_path)) {
            throw "Could not locate a source directory by convention. Searched in $($convention -join ', ')"
        }
    } else {
        Assert (Test-Path($source_path)) "Could not find source directory $source_path"
    }
    return $source_path
}


#========================================
# /Helper functions
#========================================
