properties {
	$version = if($env:BUILD_NUMBER) {$env:BUILD_NUMBER} else { "0.0.0.1" }
}

include .\master_build.ps1
include .\test_build.ps1
task default -depends compile, test

function find_file([string] $fileName)
{
  ls . -r | ?{$_.Name -match "psake.psm1$"} | select -f 1
}