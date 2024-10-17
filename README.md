# CRUD MVC Web App Consuming Web API

This project consists of two main components: 

1. **CRUDMVCusingWebAPI**:  
   This is the ASP.NET Core MVC web app that interacts with the Web API to perform CRUD (Create, Read, Update, Delete) operations.

2. **CRUDWebAPI**:  
   This is the ASP.NET Core Web API that provides endpoints to manage employee data. I have created my Web API with Entity Framework Core to use Microsoft SQL Server and connect to SQL Server Management System (SSMS).

## CRUDWebAPI Endpoints

The Web API exposes the following endpoints for handling employee data:

### [HttpGet] GetEmployees
- **Description**: Retrieves a list of all employees.
- **Route**: `/api/employees`
- **Usage**: 
  ```http
  GET /api/employees

### [HttpGet] GetEmployeeById
- **Description**: Retrieves details of a specific employee by their unique identifier (GUID).
- **Route**: `/api/employees/{id:guid}`
- **Parameters**: `id (Guid) - The unique identifier of the employee.`
- **Usage**: 
  ```http
  GET /api/employees/{id}

### [HttpPost] AddEmployee
- **Description**: Adds a new employee to the database.
- **Route**: `/api/employees`
- **Request Body**: `AddEmployeeDTO - The data transfer object containing details of the employee to be added.`
- **Usage**: 
  ```http
  POST /api/employees

### [HttpPut] UpdateEmployeeById
- **Description**: Updates an existing employee's information using their unique identifier (GUID).
- **Route**: `/api/employees/{id:guid}`
- **Parameters**: `id (Guid) - The unique identifier of the employee.`
- **Request Body**: `UpdateEmployeeDTO - The data transfer object containing updated employee details.`
- **Usage**: 
  ```http
  PUT /api/employees/{id}

### [HttpDelete] DeleteEmployeeById
- **Description**: Deletes an employee from the database using their unique identifier (GUID).
- **Route**: `/api/employees/{id:guid}`
- **Parameters**: `id (Guid) - The unique identifier of the employee.`
- **Usage**: 
  ```http
  DELETE /api/employees/{id}
