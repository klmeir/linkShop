# linkShop with .NET (Microservices) / Angular

# Services-based architecture
<img src="https://github.com/klmeir/linkShop/blob/master/img/linkshop_architecture.png" />

# The main architectural patterns and styles that guide this solution are

- Port and Adapter Architecture
- CQRS (Command Query Responsibility Segregation)

# Technical specifications:

## Microservices
- Ready to containerize with Docker.
- Entity Framework Core 6
- Generic Repository (very useful with aggregate management)
- Automatic Domain Services injection using "[DomainService]" annotation.
- MediaTR : register command handlers and queries automatically (via reflection does scan of the assembly)
- Global Exception Handler
- Logs : Console
- Swagger

## WebApp (pending...)
- Arquitectura core-shared-feature
  
### Project structure:

Solution for VisualStudio(.sln) composed of the following folders :

src/catalog-api
- Api : Api Rest, entry point of the application
- Application : Domain Services Orchestration Layer; Ports, Commands, Queries, Handlers
- Infrastructure : Adapters
- Domain : Entities, Value Objects, Ports, Domain Services, Aggregates

src/ordering-api
- Api : Api Rest, entry point of the application
- Application : Domain Services Orchestration Layer; Ports, Commands, Queries, Handlers
- Infrastructure : Adapters
- Domain : Entities, Value Objects, Ports, Domain Services, Aggregates

src/store-app
- core : Cross-cutting and single-instance in the application.
- feature : Components that implement specific functionalities of the application.
- shared : Components or utilities common to the different features.

# Build & Run

## Visual Studio 2022

To run the project open the solution in visual studio, check the database connections string and run.

## Docker and Docker Compose

The execution of docker compose from visual studio is functional, at the moment we are working to execute it from command line...

To startup the whole solution, execute the following command:

```
docker-compose build --no-cache
docker-compose up -d
```

Then the following containers should be running on `docker ps`:

| Application      | URL                                                                                |
| ---------------- | ---------------------------------------------------------------------------------- |
| Web App          | https://localhost:8000                                                           |
| Catalog API      | https://localhost:8001                                                             |
| Ordering API     | https://localhost:8002                                                             |
| SQL Server       | Server=localhost;User Id=sa;Password=<YourStrong!Passw0rd>;                        |


- Browse to [http://localhost:8000](http://localhost:8000) and view linkShop
- Browse to [http://localhost:8001](http://localhost:8001) and view the Catalog API  swagger documentation
- Browse to [http://localhost:8000](http://localhost:8000) and view the Ordering API swagger documentation

