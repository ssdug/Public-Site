## South Sound .NET User Group Public Site

This project is for the South Sound .NET Users Group.

## Project Resources

The active team are using several resources to manage the project, to gain access to some of these resources contact either Brad, Cam or Bobby.

	- Source: [http://www.github.com/ssdnug/Public-Site]
	- Live Site: http://ssdnug.apphb.com/
	- Tasks: http://www.agilezen.com
	- Communication: https://www.facebook.com/groups/175181635917238/

# Running Site Locally

To run this project locally you must have a few things installed:

	- IIS Express: http://www.microsoft.com/download/en/details.aspx?id=1038
	- TestDriven.NET*: http://testdriven.net/download.aspx
	* only if you would like to run unit tests in visual studio.

Once you have the tooling installed and the solution will build in Visual Studio, you are ready to run the site. Start by running the RavenDB server located in the packages directory.

In PowerShell from the root directory of the project:

```
C:\Projects\Public-Site [master]> .\packages\RavenDB.1.0.616\server\Raven.Server.exe
```
Note: To stop the server, type "q" and press the Enter key.


fus ro dah!