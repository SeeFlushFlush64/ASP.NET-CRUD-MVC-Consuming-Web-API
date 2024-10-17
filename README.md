# CRUD MVC Web App Consuming Web API

This project consists of two main components: 

1. **CRUDMVCusingWebAPI**:  
   This is the ASP.NET Core MVC web app that interacts with the Web API to perform CRUD (Create, Read, Update, Delete) operations.

2. **CRUDWebAPI**:  
   This is the ASP.NET Core Web API that provides endpoints to manage employee data.

## CRUDWebAPI Endpoints

The Web API exposes the following endpoints for handling employee data:

### [HttpGet] GetEmployees
- **Description**: Retrieves a list of all employees.
- **Route**: `/api/employees`
- **Usage**: 
  ```http
  GET /api/employees
  GET /api/employees/{id}
  POST /api/employees
  PUT /api/employees/{id}
  DELETE /api/employees/{id}
