
---

```markdown
# 🏛️ MiniADREC — Land & Permit Management System

MiniADREC is a modular backend system designed to manage land plots, user roles, and permit requests. Inspired by real-world government platforms, it provides a clean, scalable architecture for civic-tech applications.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- JWT-based login and token refresh
- Role-based access control (Admin, User, Broker)

### 👤 User & Role Management
- Create, update, and delete users
- Assign roles and manage access levels

### 🏘️ Plot Management
- Register and search land plots by district, land use, and owner
- Full CRUD operations with clean DTO separation

### 🧾 Permit Request Workflow
- Submit permit requests for building, renovation, etc.
- Track request status (Pending, Approved, Rejected)
- Link requests to specific users and plots

---

## 🧱 Tech Stack

| Layer         | Technology                      |
|--------------|----------------------------------|
| Language      | C# (.NET 9)                      |
| Framework     | ASP.NET Core Web API 9            |
| Database      | Entity Framework Core + SQL      |
| Auth          | JWT + Refresh Tokens             |
| Mapping       | AutoMapper                       |
| Architecture  | Clean Architecture (DDD)         |
| DI            | Scoped services via IServiceCollection |
| Caching       | Redis for caching                 |

---

## 📁 Project Structure

```
MiniADREC/
├── Domain/             # Core entities
├── DTO/                # Data transfer objects
├── Repositories/       # Interfaces & implementations
├── Services/           # Business logic
├── API/Controllers/    # RESTful endpoints
├── Context/            # EF Core DbContext & configs
├── Mappings/           # AutoMapper profiles
└── DependencyInjection/ # DI registration
```

---

## 🧪 How to Run

1. Clone the repo  
2. Configure your `appsettings.json` (DB connection, JWT secret, etc.)  
3. Run migrations:  
   ```bash
   dotnet ef migrations add InitialCreate  
   dotnet ef database update  
   ```
4. Launch the API:  
   ```bash
   dotnet run  
   ```

Use Scalar for .NET 9 latest versions or Postman to test endpoints.

---

## 🌍 Real-World Use Cases

- Municipal land registry systems  
- Real estate permit workflows  
- Smart city dashboards  
- Government e-services platforms

---

## 👨‍💻 Built By

**Muhammad** — Backend Developer passionate about civic-tech, clean architecture, and scalable systems.

---

## 📌 Future Enhancements

- File uploads for permit documents  
- GIS integration for plot mapping  
- Admin dashboard with analytics  
- Notification system for permit status

---

## 📬 Contact

Want to collaborate or hire me?  
📧 Email: m.abdullahdev2008@gmail.com  
🌐 LinkedIn: https://www.linkedin.com/in/abdullah-butt-280675352/
```

