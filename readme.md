# ASP.NET 8 CRUD App with Custom CQRS and Google PhoneNumber Validation

## Overview

This repository contains an ASP.NET 8 CRUD (Create, Read, Update, Delete) application built on top of the clean architecture. The application implements a custom Command Query Responsibility Segregation (CQRS) pattern for better separation of concerns. Additionally, it utilizes the Google `libphonenumber-csharp` library for phone number validation.

### Project Structure

- **src**: Contains the source code of the ASP.NET 8 application.
  - **Mc2.CrudTest.Presentation.Server**: The API layer responsible for handling HTTP requests and responses.
  - **Mc2.CrudTest.Presentation.Client**: The UI layer that is ready for implementing a razor-pages/MVC application in it.
  - **Mc2.CrudTest.Presentation.Shared**: This layer contains assets that are shared between the Server layer and the Client layer.
  - **Mc2.CrudTest.Persistence**: The Persistence layer handles data access and database services.
  - **Mc2.CrudTest.Core.Application**: The application layer containing the application's business logic and CQRS implementation.
  - **Mc2.CrudTest.Core.Domain**: The domain layer defining the core entities and business logic.

## Getting Started

Follow these steps to set up and run the ASP.NET 8 CRUD app locally:

1. **Clone the Repository**

    ```bash
    git clone https://github.com/twcclegg/your-repository.git
    cd your-repository
    ```

2. **Build and Run the Application**

    Open the solution in Visual Studio or use the following command in the terminal:

    ```bash
    dotnet build
    dotnet run --project src/MyApp.Api
    ```

    The application will be accessible at `http://localhost:5000`.

3. **Configure Google `libphonenumber-csharp`**

    the dll of the library is already included in the repository but if you want to use new versions you can clone it from [here](https://github.com/twcclegg/libphonenumber-csharp) and build the dll yourself.

## Usage

### API Endpoints

- **POST /api/Customer**: Create a customer.
- **GET /api/Customer/{id}**: Recive a customer info.
- **Patch /api/Customer/{id}**: Update a customer info.
- **DELETE /api/Customer/{id}**: Delete a specific customer.

### CQRS Implementation

The application follows a custom CQRS pattern for better separation of concerns. Commands and queries are handled separately in the application layer (`Mc2.CrudTest.Core.Application`). The `Mc2.CrudTest.Core.Domain` layer defines the core entities and business logic.

### Phone Number Validation

The Google `libphonenumber-csharp` library is used for phone number validation.
