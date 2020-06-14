# ServiceTemplate

This is a custom service template for .NET

How to use: 
 1) clone a repository
 2) navigate to repository local folder through terminal (bash/cmd.exe/etc.)
 3) remove local .git folder (so you wont copy this repository instead of creating your own for your service)
 4) in a solution folder in a terminal (ex.: E:/ServiceTemplate), execute: **dotnet new -i .** to register a template on your PC
 5) navigate to a folder where you want to create a new solution
 6) in a terminal, execute: **dotnet new servicetemplate -n %SolutionName%**
 
This template contains simple Angular application. If you do not require a client-side application, consider removing folder Template.Web/ClientApp and cleaning its dependencies in Startup.cs and Template.Web.csproj file.

If you require client-side application, use **npm install** on ClientApp folder to restore Angular packages.
