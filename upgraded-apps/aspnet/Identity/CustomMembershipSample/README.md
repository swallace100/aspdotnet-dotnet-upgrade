# Custom Membership Sample

## Introduction

This app was converted from a MVC app to a Blazor-based app. The authentication was also converted to AspNetCore Identity Entity Framework Core.

## Setup

The following commands were run to create the initial project and add the Entity Framework packages

```PowerShell
cd  .\upgraded-apps\aspnet\Identity\

dotnet new sln -n CustomMembershipSample
dotnet new blazor -n CustomMembershipSample

dotnet sln add ./CustomMembershipSample/CustomMembershipSample.csproj
dotnet run --project ./custommembershipsample

dotnet add .\CustomMembershipSample package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add .\CustomMembershipSample package Microsoft.EntityFrameworkCore.SqlServer
dotnet add .\CustomMembershipSample package Microsoft.EntityFrameworkCore.Tools
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialIdentity

# Read the migration C#, generate the SQL for the SQL Server DB, and execute
dotnet ef database update

```

## Run the application

```PowerShell
cd CustomMembershipSample
dotnet run
```
