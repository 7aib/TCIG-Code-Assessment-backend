# TCIG Code Assessment - Backend API

A .NET 8 Web API project for managing products with a clean architecture approach using Clean Architecture principles.

## 🏗️ Architecture

This project follows Clean Architecture with the following layers:

- **TCIG.API** - Web API layer with controllers and endpoints
- **TCIG.Application** - Application layer with services, DTOs, and business logic
- **TCIG.Domain** - Domain layer with entities, interfaces, and enums
- **TCIG.Infrastructure** - Infrastructure layer with data access and repositories

## 🚀 Features

- **Product Management**: Full CRUD operations for products
- **Clean Architecture**: Separation of concerns with dependency injection
- **Entity Framework Core**: Database operations with migrations
- **AutoMapper**: Object-to-object mapping
- **FluentValidation**: Input validation
- **Swagger/OpenAPI**: API documentation
- **Async/Await**: Asynchronous programming patterns

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## 🛠️ Installation & Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd TCIG-Code-Assessment-backend
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   - Open `TCIG.API/appsettings.json` or `TCIG.API/appsettings.Development.json`
   - Update the connection string to point to your SQL Server instance:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TCIGProductsDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Run database migrations**
   ```bash
   cd TCIG.API
   dotnet ef database update
   ```

5. **Build and run the application**
   ```bash
   dotnet build
   dotnet run
   ```

6. **Access the application**
   - API: `http://localhost:5000`
   - Swagger UI: `http://localhost:5000/swagger`

## 📚 API Endpoints

### Products Controller (`/api/products`)

| Method | Endpoint | Description | Request Body |
|--------|----------|-------------|--------------|
| GET | `/api/products` | Get all products | - |
| GET | `/api/products/{id}` | Get product by ID | - |
| POST | `/api/products` | Create new product | `CreateProductDto` |
| PUT | `/api/products/{id}` | Update existing product | `UpdateProductDto` |
| DELETE | `/api/products/{id}` | Delete product | - |

### Data Transfer Objects (DTOs)

#### ProductDto
```json
{
  "id": 1,
  "productName": "Sample Product",
  "price": 99.99,
  "stock": 100,
  "status": "Active",
  "image": "product-image.jpg",
  "createdDate": "2024-01-01T00:00:00Z",
  "updatedDate": "2024-01-01T00:00:00Z"
}
```

#### CreateProductDto
```json
{
  "productName": "New Product",
  "price": 49.99,
  "stock": 50,
  "status": "Active",
  "image": "new-product.jpg"
}
```

#### UpdateProductDto
```json
{
  "productName": "Updated Product",
  "price": 79.99,
  "stock": 75,
  "status": "Active",
  "image": "updated-product.jpg"
}
```

### Product Status Enum
- `Active` - Product is available
- `Inactive` - Product is not available
- `Discontinued` - Product is discontinued

## 🗂️ Project Structure

```
TCIG-Code-Assessment-backend/
├── TCIG.API/                    # Web API Layer
│   ├── Controllers/             # API Controllers
│   ├── Properties/              # Launch settings
│   └── Program.cs               # Application entry point
├── TCIG.Application/            # Application Layer
│   ├── DTOs/                    # Data Transfer Objects
│   ├── Interfaces/              # Service interfaces
│   ├── Mappings/                # AutoMapper profiles
│   ├── Services/                # Business logic services
│   └── Validators/              # FluentValidation validators
├── TCIG.Domain/                 # Domain Layer
│   ├── Entities/                # Domain entities
│   ├── Interfaces/              # Repository interfaces
│   └── enums/                   # Domain enums
├── TCIG.Infrastructure/         # Infrastructure Layer
│   ├── Data/                    # DbContext and DI configuration
│   ├── Migrations/              # EF Core migrations
│   └── Repositories/            # Data access implementations
└── README.md                    # This file
```

## 🔧 Technologies Used

- **.NET 8** - Framework
- **ASP.NET Core Web API** - Web API framework
- **Entity Framework Core** - ORM
- **SQL Server** - Database
- **AutoMapper** - Object mapping
- **FluentValidation** - Input validation
- **Swagger/OpenAPI** - API documentation

## 🧪 Testing the API

### Using Swagger UI
1. Navigate to `http://localhost:5000/swagger`
2. Use the interactive interface to test endpoints

### Using HTTP Client
Example requests using curl:

**Get all products:**
```bash
curl -X GET "http://localhost:5000/api/products"
```

**Create a product:**
```bash
curl -X POST "http://localhost:5000/api/products" \
  -H "Content-Type: application/json" \
  -d '{
    "productName": "Test Product",
    "price": 29.99,
    "stock": 10,
    "status": "Active",
    "image": "test.jpg"
  }'
```

**Update a product:**
```bash
curl -X PUT "http://localhost:5000/api/products/1" \
  -H "Content-Type: application/json" \
  -d '{
    "productName": "Updated Product",
    "price": 39.99,
    "stock": 15,
    "status": "Active",
    "image": "updated.jpg"
  }'
```

**Delete a product:**
```bash
curl -X DELETE "http://localhost:5000/api/products/1"
```

## 🗄️ Database Schema

### Products Table
| Column | Type | Description |
|--------|------|-------------|
| Id | int | Primary key, auto-increment |
| ProductName | nvarchar(100) | Product name (required) |
| Price | decimal(18,2) | Product price (required, 1-10000) |
| Stock | int | Stock quantity (required, >= 0) |
| Status | int | Product status (enum) |
| Image | nvarchar(max) | Product image URL (optional) |
| CreatedDate | datetime2 | Creation timestamp |
| UpdatedDate | datetime2 | Last update timestamp |

## 🚀 Deployment

### Development
```bash
dotnet run --project TCIG.API
```

### Production
```bash
dotnet publish -c Release -o ./publish
cd publish
dotnet TCIG.API.dll
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is part of the TCIG Code Assessment.

## 🆘 Support

If you encounter any issues or have questions, please create an issue in the repository.

---

**Note**: This is a code assessment project demonstrating clean architecture principles and modern .NET development practices.
