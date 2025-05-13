# 🔐 Employee Leave Management System - Authentication API

This is the backend authentication module of the Employee Leave Management System. It provides secure user registration and login using **ASP.NET Core Identity** and **JWT (JSON Web Tokens)** for authentication and authorization.

## 🚀 Features

- 🔒 JWT-based Authentication
- 🧑 Role-Based Authorization (Admin, Employee, etc.)
- 📧 Email-based Registration & Login
- ✅ ASP.NET Core Identity integration
- 🔐 Secure token generation with expiration

## 🛠️ Tech Stack

- ASP.NET Core 8
- ASP.NET Identity
- Entity Framework Core
- SQL Server
- JWT Authentication
- C#

## 📁 API Endpoints

### 🔹 `POST /api/auth/register`

Registers a new user.

#### Request Body

```json
{
  "fullName": "Vijay chandra",
  "email": "vijay@example.com",
  "password": "YourStrong@Password1",
  "role": "Admin"
}
