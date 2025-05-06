# Ecommerce-app

# 🛒 E-Commerce Platform (Microservices-based)

This project is a modular, microservices-based **E-Commerce Platform** designed with high scalability, security, and code quality in mind. It supports both **B2C** operations and **multi-seller marketplaces**, enabling customers to browse products, place orders, track shipments, and more. 

> ⚠️ **Note:** This project is in its early development stage. I’m building it in my spare time outside of my full-time job. Codebase and services will be added incrementally with a focus on clean architecture, scalability, and real-world practices.

---

## ✅ Key Features

- 👥 **Multi-role support**: Customer, Seller Admin, Super Admin
- 🛍️ Browse products by category with filters and related items
- 🛒 Shopping cart, order creation, return requests
- 💳 Wallet support and payments (planned)
- 🔄 Order & delivery tracking
- 📦 Seller-specific inventory management
- 🚫 Super Admin: block/unlist sellers or products
- 📸 Multi-image product upload and management
- 🧾 Clean separation of concerns using **CQRS**, **Hexagonal Architecture**, and **Microservices**

---

## 🧱 Tech Stack

### Backend
- **.NET 8** with **C#**
- **Microservices architecture**
- **Entity Framework Core** + **Dapper**
- **SQL Server** for relational services
- **MongoDB** for NoSQL-based services (e.g., product catalog, logging)
- **Redis Cache** for performance and state caching
- **CQRS pattern** for clear Command & Query segregation
- **Fluent Validation**
- **Repository Pattern** with Ports & Adapters (Hexagonal Architecture)
- **RBAC** (Role-Based Access Control)
- **XUnit** for Unit Testing

### Frontend
- **ReactJS**
- **Zustand** for state management
- **Micro Frontend Architecture**
- **TailwindCSS** for styling

### AI & Machine Learning
- Will add AI driven features as well (Features are not decided yet, Ex: Voice driven search) 

---

## ☁️ Azure Services Used

| Azure Service          | Purpose                                                                 |
|------------------------|-------------------------------------------------------------------------|
| Azure App Services     | Hosting APIs and Frontend apps                                          |
| Azure Kubernetes Service (AKS) | Container orchestration and scaling                              |
| Azure Container Registry | Docker image registry for microservices                              |
| Azure Blob Storage     | To store product images and static content                              |
| Azure SQL Database     | Hosting the relational database                                          |
| Azure Cosmos DB        | For document-based storage needs (e.g., product catalog)                |
| Azure Key Vault        | Secure storage of secrets, keys, and configurations                     |
| Azure Redis Cache      | Improve response times and support scaling                              |
| Azure Monitor / App Insights | Application telemetry, logging, and performance monitoring        |
| Azure DevOps           | CI/CD pipelines and project management                                  |

---

## 🧩 Microservices (Planned/Implemented)

| Service Name     | Purpose                                   | DB Used      | Status         |
|------------------|--------------------------------------------|--------------|----------------|
| Auth Service      | Login, registration, JWT tokens, RBAC     | SQL Server   | ✅ In Progress |
| Product Service   | Product catalog, categories, images       | MongoDB      | ⏳ Planned     |
| Order Service     | Manage orders, returns, statuses          | SQL Server   | ⏳ Planned     |
| Inventory Service | Seller-specific stock management          | SQL Server   | ⏳ Planned     |
| Wallet Service    | Manage wallet balance and transactions    | SQL Server   | ⏳ Planned     |
| Notification Service | Email/SMS/push notifications           | MongoDB      | ⏳ Planned     |
| Admin Portal      | Organization/Seller management            | SQL Server   | ⏳ Planned     |

---

## 🚀 Deployment Strategy

- All services are **containerized** using Docker
- Services are deployed and scaled using **Azure Kubernetes Service (AKS)**
- Secrets and environment-specific settings are managed with **Azure Key Vault**
- CI/CD pipelines managed via **Azure DevOps**
- Blue-Green deployment strategy to minimize downtime

---

## 📌 Status

This is a **learning-first** and **portfolio-focused** project, meant to demonstrate real-world skills in:

- Building scalable distributed systems
- Clean code and architecture principles
- Advanced Azure DevOps and cloud-native deployments

More updates will follow as time permits. Stay tuned!



---

## 🙋‍♂️ About Me

I’m a **Lead Software Engineer** and **Application Architect** with 15+ years of experience in the Microsoft stack. I'm currently exploring AI, Cloud, and distributed architectures with a goal of becoming an AI Architect. Connect with me on [LinkedIn](https://www.linkedin.com/in/vinit-kumar-19284717/) to follow the project’s progress and updates.
I am looking for contributers to work with me on this project.

