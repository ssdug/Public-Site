properties {
	$ravendb_dir = "$tool_dir\RavenDB.1.0.701"
	$ravendb_server = "$ravendb_dir\server\Raven.Server.exe"
}

task server {
	Write-Host "starting RavenDB Server"
	& $ravendb_server
}

task clean-data {
	Write-Host "destroying RavenDB Data"
	rm -r -for "$ravendb_dir\server\data"
}