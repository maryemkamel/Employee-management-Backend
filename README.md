# Employee Management API

## Overview

The Employee Management API is a robust web service built with ASP.NET Core, specializing in CRUD (Create, Read, Update, Delete) operations for managing employee data. It employs the CQRS (Command Query Responsibility Segregation) pattern to maintain a clear distinction between data modification and retrieval processes, ensuring a scalable and maintainable codebase.

## Key Features

- **Create Employee**: Enables the addition of new employee records.
- **Read Employee**: Provides access to employee details by ID or retrieves a comprehensive list of all employees.
- **Update Employee**: Facilitates modification of existing employee information.
- **Delete Employee**: Supports the removal of employee records from the database.

## Technologies Used

- **ASP.NET Core**: Framework used for building the API backend.
- **SQLite**: Embedded database engine employed for storing and managing employee data.
- **MediatR**: Library utilized for implementing the CQRS pattern, enhancing separation of concerns.
- **Angular**: Frontend framework utilized for user interface development and interaction.

## CQRS Pattern

- **Commands**: Handles operations that modify data (e.g., create, update, delete).
- **Queries**: Manages operations that retrieve data without altering it.

## Database Configuration

The API utilizes SQLite as its embedded database engine. The connection string named `DefaultConnection` points to `Data Source=employee_management.db`.

