## South Sound .NET User Group Public Site

This project is for the South Sound .NET Users Group.

## Project Resources

The active team are using several resources to manage the project, to gain access to some of these resources contact either Brad, Cam or Bobby.

- Source: [http://www.github.com/ssdnug/Public-Site](http://www.github.com/ssdnug/Public-Site)
- Live Site: http://ssdnug.apphb.com/
- Tasks: http://www.agilezen.com
- Communication: https://www.facebook.com/groups/175181635917238/


# Building The Site

There is a common psake based tasks script located in the root of the source repository. To build the site open PowerShell and issue the following command:

```
C:\Projects\Public-Site [master]> .\tasks.ps1
```

This will compile the source and execute all tests, which are the default tasks defined in the tasks.ps1.

# Running RavenDB Server Locally

The project uses RavenDB as a data store. To run the site locally you must have the RavenDB server running. You can use the following command in PowerShell to start the server:

```
C:\Projects\Public-Site [master]> .\tasks.ps1 server
```

Note: To stop the server, type "q" and press the Enter key.

You can browse the RavenDB management site at http://localhost:8080

You may want to clear all data out of the database to get to a clean state, to do so use the following command from PowerShell:

```
C:\Projects\Public-Site [master]> .\tasks.ps1 clean-data
```
There is a backup file located in docs/inital-data/InitalData.raven.dump. You can use the import task in the RavenDB management site to import the backup to get some sample data into your database.

## fus ro dah!