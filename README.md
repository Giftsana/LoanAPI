# Loan API
Simple ASP.NET Core Web API for managing loan applications.
## Tech Stack
- .NET Core Web API
- C#
- Entity Framework Core
- SQL Server
  
Phase 1: In-memory storage

## Features
- Apply for loan
- Get all loans
- Get loans by customer


## Endpoints
GET /api/loan  
GET /api/loan/{customerId}  
POST /api/loan/apply  

## Sample Request
{
  "customerId": 1,
  "amount": 500
}

Phase 2: Database Integration SQL Server with Service layer added
- Integrated SQL Server using EF Core
- Implemented DbContext for data access
- Added Service Layer for business logic
- Removed in-memory repository
- Implemented async operations

Phase 3: Added patch endpoint for updating loan amopunt
## Sample request
PATCH /api/loan/10/amount
