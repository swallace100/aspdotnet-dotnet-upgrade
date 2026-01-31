# ASP.NET → .NET 10 Migration Samples

This repository contains example projects demonstrating how to migrate legacy ASP.NET (System.Web) applications to modern .NET 10, ASP.NET Core, and Blazor.
The samples are adapted from the official [ASP.NET Samples](https://github.com/aspnet/samples), upgraded progressively to modern .NET tooling, project structures, and APIs.

The goal is to provide real working examples that show the upgrade path step-by-step, including common issues, solutions, and modernization strategies.

## Repository Goals

| Topic                         | Description                                                 |
| ----------------------------- | ----------------------------------------------------------- |
| Understanding migration paths | Compare legacy ASP.NET and modern .NET 10 equivalents       |
| Real sample upgrades          | Fully functioning upgraded apps for reference and testing   |
| Troubleshooting experience    | Document common issues encountered during migration         |
| Modern hosting models         | Minimal Hosting Model, Middleware, and Dependency Injection |
| Client modernization          | Examples using Blazor for UI modernization                  |

## Repository Structure

```code
ASPDOTNET-DOTNET-UPGRADE
│
├── legacy-apps/ # Original .NET Framework sample applications
│ └── aspnet/
│ ├── HttpClient
│ ├── Identity
│ ├── Katana
│ ├── MVC
│ ├── WebApi
│ └── README.md
│
├── upgraded-apps/ # Migrated versions targeting modern .NET
│ ├── aspnet/ # Upgraded classic projects (.NET 10 equivalent architectures)
│ └── aspnetcore/ # ASP.NET Core upgrades with Blazor and minimal hosting
│
├── global.json # SDK pinning to ensure correct tooling versions
├── CODE-OF-CONDUCT.md
├── LICENSE
└── README.md # You are here
```

## Tech Stack

- .NET 10 SDK
- ASP.NET Core 10
- Blazor / Razor Components
- Minimal API hosting model
- HttpClient, Identity, Katana, MVC, Web API modernization
- Docker support (planned)
- GitHub Actions CI/CD (planned)

## Migration Concepts Demonstrated

Classic ASP.NET → .NET 10 equivalents

| Legacy Feature         | .NET 10 Equivalent                              |
| ---------------------- | ----------------------------------------------- |
| Global.asax / Startup  | Program.cs Minimal Hosting                      |
| Web.config             | appsettings.json + DI-based configuration       |
| System.Web HttpContext | HttpContext via DI in Controllers & Minimal API |
| App_Start RouteConfig  | Endpoint Routing                                |
| Web API 2              | ASP.NET Core Web API                            |
| MVC5 Controllers       | MVC Controllers / Razor / Blazor                |
| HttpClient Samples     | HttpClientFactory                               |

## Running the Upgraded Samples

```bash
cd upgraded-apps/aspnetcore/<SampleFolder>
dotnet restore
dotnet run
```

To verify installed runtimes:

```bash
dotnet --list-runtimes
```

## License

MIT — free to use for learning, teaching, and professional migrations.
