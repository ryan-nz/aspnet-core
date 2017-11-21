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
- SQLExpress (PS. I will test on MySql server on docker of Linux)


## Some key points to complete this project

- Add "Entity Framework packages" into *.csproj (Note: project.json disappeared from Core 1.1)

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0" />
    <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="2.0.0" />
  </ItemGroup>
```
