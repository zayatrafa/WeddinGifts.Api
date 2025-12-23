# WeddinGifts API

A RESTful API built with **ASP.NET Core (.NET 8)** to manage wedding gifts.

This project was developed with a **learning-first and professional approach**, serving as a **backend portfolio project**. It demonstrates API design, database persistence, and basic frontend consumption.

---

## Overview

WeddinGifts API allows users to create and retrieve wedding gift records through a clean and RESTful HTTP interface. The project follows modern .NET backend practices, including separation of concerns, dependency injection, data validation, and database migrations.

---

## Features

- Create wedding gifts
- List all gifts
- Retrieve a gift by ID
- SQL Server database persistence
- Input validation using DTOs
- Execution flow logging
- Simple HTML frontend for API consumption

---

## Project Structure

```
WeddinGifts.Api
│
├── Controllers
│   └── GiftsController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Dtos
│   └── CreateGiftDto.cs
│
├── Models
│   └── Gift.cs
│
├── Migrations
│
├── wwwroot
│   └── index.html
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server (LocalDB)
- Swagger / OpenAPI
- HTML and JavaScript (Fetch API)
- Dependency Injection
- Built-in ASP.NET Core Logging

---

## Available Endpoints

### Create Gift

**POST** `/api/gifts`

Request body example:

```json
{
  "name": "Coffee Maker",
  "description": "Electric coffee machine",
  "price": 399.90
}
```

---

### List All Gifts

**GET** `/api/gifts`

---

### Get Gift by ID

**GET** `/api/gifts/{id}`

---

## Swagger Documentation

During development, interactive API documentation is available at:

```
/swagger
```

---

## Simple Frontend

A simple HTML frontend is available at:

```
/index.html
```

It allows:

- Creating gifts
- Consuming the API via JavaScript Fetch API
- Testing the backend outside of Swagger

---

## Database

- Database: SQL Server LocalDB
- ORM: Entity Framework Core
- Approach: Code First
- Schema versioning via Migrations

### Creating the Database

After cloning the repository, run the following command in the Package Manager Console:

```
Update-Database
```

---

## Concepts Applied

- RESTful API design
- Dependency Injection (DI)
- DTOs for input validation
- Separation of concerns
- Database schema versioning with migrations
- Request execution flow logging
- ASP.NET Core HTTP pipeline

---

## Project Purpose

This project was built to:

- Strengthen modern backend development skills using .NET
- Serve as a professional portfolio project
- Demonstrate understanding of the HTTP request lifecycle
- Practice integration between API, database, and frontend

---

## Future Improvements

- PUT and DELETE endpoints
- Service layer abstraction
- Authentication and authorization (JWT)
- Cloud deployment (AWS or Azure)
- Improved frontend (React or Next.js)

---

## Author

Rafael Zayat  
Backend Developer  

Project built for study and professional growth.
