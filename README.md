# bistro-q-api

## Introduction

This is the RESTAPI project for BistroQ, a POS app for restaurants, allowing restaurant owners to manage orders, tables, and menus efficiently. The API provides endpoints for various operations such as creating orders, updating menu items, and managing user roles.

## Dependencies

- ASP .NET Core 8.0
- MySQL 8 (w/ EF Core)
- ...

## Architecture

The API follows **Layered Architecture Pattern**, and separates into 4 Projects inside a Solution:

- **Core Layer**: Contains Dtos, Models and Interfaces.
- **Infrastructure Layer**: Also called Data Access Layer, implements Repositories and DbContext.
- **Services Layer**: Implements business logic and application services.
- **API Layer**: Manages HTTP requests, client communication and application's configuration.


Folder Structure:
```
.
├── BistroQ.API
│   ├── Configurations
│   ├── Controllers
│   │   ├── Auth
│   │   ├── Category
│   │   ├── Product
│   │   ├── Table
│   │   └── Zone
│   ├── Middlewares
│   └── Properties
├── BistroQ.Core
│   ├── Common
│   │   ├── Builder
│   │   └── Settings
│   ├── Dtos
│   │   ├── Auth
│   │   ├── Category
│   │   ├── Products
│   │   ├── Tables
│   │   └── Zones
│   ├── Entities
│   ├── Enums
│   ├── Exceptions
│   ├── Interfaces
│   │   ├── Repositories
│   │   └── Services
│   ├── Mappings
│   └── Specifications
├── BistroQ.Infrastructure
│   ├── Data
│   ├── Migrations
│   ├── Repositories
│   └── UnitOfWork
├── BistroQ.Services
│   └── Services
└── bistro-q-api
```

Visit our report to see more: [HackMD](https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/tondeptrai)

## Design patterns

> [!CAUTION] 
> Please fill in something here.

## Migrations

Because of the refactor in project structure, running migrations requires specifying the projects as shown below:

#### Add migrations

```bash
dotnet ef migrations add --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext --configuration Debug --verbose AutoCreateOrderIdAndOrderItemId --output-dir Migrations
```

#### Apply migrations

```bash
dotnet ef database update --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext --verbose 
```

## Testing

We have written unit tests for controller. To run it, follows the below instructions: 

#### Using `dotnet` CLI

```bash
dotnet test
```

#### Using Visual Studio/Jetbrains Rider

Run the test using the Test Explorer/Test Runner in your IDE.
