if(-not(Get-Module -name psake)) {	
	ls . -r | ?{$_.Name -match "psake.psm1$"} | ForEach-Object {
			Import-Module $_.FullName
		}
}