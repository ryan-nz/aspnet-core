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
- MS SQLExpress (PS. Refer to 'PilotWorksAPI-ForMySql' for MySql server running on Linux docker hosted on Windows 10)


## Some key points to complete this project
- Add "Microsoft.AspNetCore.All" into *.csproj (Note: project.json disappeared from Core 1.1)

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0" />
  </ItemGroup>
```