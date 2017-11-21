## Skills Prerequisites
- C#
- ORM (Object Relational Mapping) Note: You may use dynamic way for mapping.
- Web API (RESTful)
- EF
- Code First
- Dependency Injection
- TDD (Mocker Testing)


## Software Prerequisites
- Visual Studio 2017
- MySql (running on Linux docker which is set up on my Windows 10)
  1. mysql-installer-community-5.7.20.0.msi installed if want to use MySql WorkBench.
  2. mysql-for-visualstudio-1.2.7.msi installed if want to use database connection tool in Visual Studio.
- Docker, I installed Docker Toolbox (Docker version 17.07.0-ce, build 8784753)
- Docker image: centurylink/mysql (ubuntu:14.04)
  - Refer to: https://hub.docker.com/r/centurylink/mysql/


## Some key points to complete this project
- Add "Microsoft.AspNetCore.All" into *.csproj (Note: project.json disappeared from Core 1.1)

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0" />
  </ItemGroup>
```

## About MySQL EF for .NET CORE 2.0
- Put `Pomelo.EntityFrameworkCore.MySql` into your project's .csproj file.
```xml
  <ItemGroup>
    <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="2.0.0.1" />
  </ItemGroup>
```
Note:
1. At the moment (22 Novemer, 2017), No MySql EF for .NET EF CORE 2.0 offial release.
2. Instead use `Pomelo.EntityFrameworkCore.MySql`. Please refer to `Pomelo EF Core Database Provider for MySQL` (https://docs.microsoft.com/en-us/ef/core/providers/pomelo/)
