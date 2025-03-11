# BistroQ API

A comprehensive backend API for a restaurant management system, serving a WinUI client application.

## Links

- Milestone 1 Report: [https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/](https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/)
- Milestone 2 Report: [https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/HkhqJdrz1g](https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/HkhqJdrz1g)
- Milestone 3 Report: [https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/SywYnZt81l](https://hackmd.io/@CXS0caWySWi1obKmwFzL-Q/SywYnZt81l)

## 📋 Overview

BistroQ API is a RESTful backend service designed to handle all operations for a modern restaurant management system. It provides endpoints for order management, product catalog, user authentication, and more. This project was developed as part of the CSC13001 Windows Development course at HCMUS.

## 🔍 Features

### 🔐 Authentication & Authorization
- JWT-based authentication with access and refresh tokens
- Role-based access control (Admin, Kitchen, Cashier, Client)
- User account management

### 🍽️ Restaurant Management
- **Zone & Table Management**: Create and manage dining zones and tables
- **Product Catalog**: Manage menu items with nutritional information
- **Category Management**: Organize products into categories
- **Order Processing**: Handle order creation, updates, and status tracking

### 💼 Order Lifecycle
- **Client Orders**: Customers can create orders, add/remove items
- **Kitchen Management**: Kitchen staff can view and update order item status
- **Cashier Operations**: Process payments and handle checkouts
- **Real-time Updates**: SignalR hubs for real-time notifications

### 📊 Smart Features
- **Nutritional Analysis**: Track nutritional information of ordered items
- **Product Recommendations**: AI-based recommendations based on nutritional balance
- **Image Management**: Upload and serve product images via AWS S3/CloudFront

## 🏗️ Architecture

### Clean Architecture

BistroQ API implements Clean Architecture principles to create a maintainable, testable, and scalable system with clear separation of concerns:

#### Core/Domain Layer (BistroQ.Core)
- Contains business entities, domain logic, and interfaces
- Defines the core business rules and entities
- Includes DTOs, interfaces, exceptions, and domain models
- Has no dependencies on other layers or external frameworks
- Defines contracts that outer layers must implement

#### Application/Service Layer (BistroQ.Services)
- Contains business logic and use cases
- Implements service interfaces defined in the Core layer
- Orchestrates the flow of data between entities
- Contains validation, business rules, and transaction management
- Depends only on the Core layer (domain interfaces)

#### Infrastructure Layer (BistroQ.Infrastructure)
- Provides implementations for interfaces defined in the Core layer
- Contains database access (Entity Framework Core), external services
- Implements repositories, data access, and persistence logic
- Contains AWS S3 integration for image storage
- Implements the Unit of Work pattern for transaction management

#### Presentation Layer (BistroQ.API)
- Contains controllers, middleware, and API endpoints
- Handles HTTP requests and responses
- Configures dependency injection and routes
- Maps external requests to internal commands/queries
- Forms the entry point to the application

#### Dependency Flow
- Dependencies flow inward, with the Core layer having no external dependencies
- Outer layers depend on inner layers through interfaces
- Dependency Injection is used to implement Inversion of Control
- All layers communicate via defined interfaces, ensuring loose coupling

### Project Structure
- **BistroQ.API**: API endpoints, controllers, middleware, and configurations
- **BistroQ.Core**: Domain entities, DTOs, interfaces, and exceptions
- **BistroQ.Infrastructure**: Database context, repositories, and data access
- **BistroQ.Services**: Business logic, services implementation
- **BistroQ.Tests**: Unit tests for controllers and services

### Design Patterns
- **Repository Pattern**: Abstracts data access logic
- **Unit of Work**: Manages transactions and data persistence
- **Dependency Injection**: For loose coupling and testability
- **Builder Pattern**: For constructing complex queries
- **Specification Pattern**: For encapsulating query logic

### Technology Stack
- **Framework**: ASP.NET Core 8.0
- **Database**: MySQL with Entity Framework Core
- **Authentication**: JWT with Identity
- **Real-time Communication**: SignalR
- **Cloud Services**: AWS S3 for storage, CloudFront for CDN
- **Testing**: MSTest

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- MySQL Server
- AWS Account (for image storage)
- Git

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/bistro-q-api.git
   cd bistro-q-api
   ```

2. **Configure environment variables**
   Copy the `.env.sample` file to `.env` and update the values:
   ```bash
   cp BistroQ.API/.env.sample .env
   ```

   The following environment variables need to be configured:
   - Database connection string
   - JWT settings
   - AWS credentials (for image storage)
   - Payment gateway credentials

3. **Apply database migrations**
   ```bash
   dotnet ef database update --project BistroQ.Infrastructure --startup-project BistroQ.API --context BistroQ.Infrastructure.Data.BistroQContext
   ```

4. **Run the application**
   ```bash
   cd BistroQ.API
   dotnet run
   ```

5. **Access the API documentation**
   Navigate to `https://localhost:7034/swagger` in your browser to view the API documentation.

## 📊 API Endpoints

The API is structured around the following main controllers:

### Authentication
- `POST /api/Auth/login`: Login with username and password
- `POST /api/Auth/refresh`: Refresh access token

### Client Operations
- `GET /api/Client/Order`: View current order
- `POST /api/Client/Order`: Create a new order
- `PATCH /api/Client/Order/PeopleCount`: Update people count
- `POST /api/Client/Order/Items`: Add items to order
- `DELETE /api/Client/Order/Items`: Remove items from order

### Kitchen Operations
- `GET /api/Kitchen/Order`: View pending orders
- `PATCH /api/Kitchen/Order/Status`: Update order item status

### Cashier Operations
- `GET /api/Cashier/Order`: View all current orders
- `GET /api/Cashier/Order/{tableId}`: Get order by table
- `PATCH /api/Cashier/Order/Status`: Update order status
- `GET /api/Cashier/Zones`: Get zones with checkout status

### Admin Operations
- `GET /api/Admin/Category`: Manage product categories
- `GET /api/Admin/Product`: Manage menu items
- `GET /api/Admin/Zone`: Manage dining zones
- `GET /api/Admin/Table`: Manage tables
- `GET /api/Admin/Account`: User account management

## 🔄 Data Synchronization

The system uses a combination of RESTful APIs and SignalR hubs to maintain real-time data synchronization between clients:

- `CheckoutHub`: Real-time notifications for checkout operations

## 🌟 Smart Features

### Nutritional Analysis
The system tracks nutritional information (calories, protein, fat, fiber, carbohydrates) for all menu items and calculates the total nutritional content of orders.

### Product Recommendations
The API includes a recommendation engine that analyzes the nutritional content of a customer's current order and suggests complementary items to achieve a balanced meal.

## 🧪 Testing

Run the test suite with:

```bash
dotnet test
```

## 📝 License

This project is part of an academic course and may be subject to specific licensing requirements of HCMUS.

## 🙏 Acknowledgements

- CSC13001 course instructors and teaching assistants
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [AWS SDK for .NET](https://aws.amazon.com/sdk-for-net/)

---

Developed as a project for CSC13001 Windows Development course at HCMUS.
