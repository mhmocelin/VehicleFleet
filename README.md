# Fleet Management Application  

## Overview  
This is a fleet management application built with **.NET 8**, following **Domain-Driven Design (DDD)** principles and **SOLID** best practices to ensure a clean, maintainable, and scalable architecture.

# Features  
| Feature               | Description                                                                 |
|-----------------------|-----------------------------------------------------------------------------|
| **Add Vehicle**       | Enforces unique chassis ID and type-specific passenger rules.               |
| **Edit Vehicle**      | Only color can be modified after creation.                                  |
| **List Vehicles**     | Returns all vehicles with details.                                          |
| **Find Vehicle**      | Search by chassis ID (series + number).               

## Technologies  
- **Backend**: .NET 8 (ASP.NET Core Web API)  
- **Persistence**: Entity Framework Core (Code-First)  
- **Testing**: xUnit + Moq  
- **Validation**: FluentValidation

- ### Prerequisites  
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
