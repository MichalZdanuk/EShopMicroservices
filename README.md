# 🛒 EShop Microservices

This repository follows the Udemy course **[Microservices Architecture and Implementation on .NET](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/)** by **Mehmet Ozkaya**.

The course provides a hands-on approach to building **.NET 8 Microservices** using industry best practices.

The original source code from the course can be found in **[Mehmet Ozkaya's GitHub repository](https://github.com/mehmetozkaya/EShopMicroservices-Udemy-Sections)**.

---

## 🚀 Overview

This project demonstrates the implementation of **e-commerce microservices** using **.NET 8** and various modern tools, frameworks and patterns, including:

- **ASP.NET Core Web API** & **Minimal APIs**
- **CQRS & MediatR** for clean separation of concerns
- **RabbitMQ & MassTransit** for event-driven communication
- **PostgreSQL, Redis, SQLite, SQL Server** for data persistence
- **gRPC** for high-performance inter-service communication
- **YARP API Gateway** for efficient API management
- **Docker & Docker Compose** for microservices orchestration

---

## 🏗️ Architecture

The project follows a **Clean Architecture** approach with **DDD (Domain-Driven Design)**, **CQRS**, and **Event-Driven Communication**.

The solution consists of multiple microservices:

- **Catalog Microservice** (Minimal APIs, Marten Document DB)
- **Basket Microservice** (Redis, RabbitMQ, MassTransit)
- **Discount Microservice** (gRPC, SQLite, EF Core)
- **Ordering Microservice** (DDD, CQRS, SQL Server)
- **YARP API Gateway** (Reverse Proxy, Rate Limiting)
- **Web UI (ShoppingApp)** (ASP.NET Core Razor, Refit)

![eshop_diagram](https://github.com/user-attachments/assets/32b56937-eb2d-4823-9f46-383ace036a05)

---

## 🛠️ Tech Stack

The project utilizes the latest technologies in the **.NET ecosystem**:

- **.NET 8 & C# 12**
- **MediatR, FluentValidation, Mapster**
- **Marten (PostgreSQL DocumentDB)**
- **Entity Framework Core**
- **MassTransit & RabbitMQ**
- **gRPC Communication**
- **Docker & Docker Compose**
- **YARP API Gateway**

---

## 📂 Project Structure

```
EShopMicroservices/
│── src/
│   ├── Services/
│   │   ├── Catalog/
│   │   ├── Basket/
│   │   ├── Discount/
│   │   ├── Ordering/
│   ├── API Gateway/
│   ├── WebUI/
│── docker-compose.yml
│── docker-compose.override.yml
│── README.md
```

Each microservice is independently developed and communicates via **RabbitMQ and gRPC**.

---

## 🏃 How to Run the Application

To run the entire microservices system locally using **Docker**, execute the following commands:

```bash
git clone https://github.com/MichalZdanuk/EShopMicroservices.git
```
```bash
cd EShopMicroservices/src
```
```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up
```

Once started, you can access the services through the **YARP API Gateway**.

---

## 📚 Additional Resources

- **Course**: [Microservices Architecture and Implementation on .NET](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/)
- **Original Repository**: [Mehmet Ozkaya's GitHub](https://github.com/mehmetozkaya/EShopMicroservices-Udemy-Sections)
- **.NET Documentation**: [docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/)
