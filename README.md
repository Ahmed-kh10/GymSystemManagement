# 🏋️ Gym Management System

A complete **Gym Management System** built using **ASP.NET Core MVC**, following **N-Tier Architecture**, **Repository Pattern**, and **Unit of Work** principles.

This project allows gym administrators to manage members, trainers, plans, memberships, sessions, and bookings through a clean and user-friendly dashboard.

---

# 🚀 Features

### 👤 Authentication
- Cookie Authentication
- Login
- Logout
- Access Denied Page

---

### 👥 Members
- Add Member
- Update Member
- Delete Member
- View Member Details
- Search Members

---

### 💪 Trainers
- Add Trainer
- Update Trainer
- Delete Trainer
- View Trainer Details

---

### 📅 Sessions
- Create Session
- Edit Session
- Delete Session
- View Session Details
- Session Capacity
- Session Status
  - Upcoming
  - Ongoing
  - Finished

---

### 📋 Membership Plans
- Create Plans
- Edit Plans
- Delete Plans
- View Plans

---

### 💳 Memberships
- Assign Memberships
- Membership Validation
- Active Membership Checking

---

### 📌 Booking Management
- Book Members into Sessions
- Cancel Booking
- Mark Attendance
- Prevent Duplicate Booking
- Prevent Booking in Full Sessions
- Prevent Booking Without Active Membership

---

# 🛠 Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- LINQ
- Bootstrap 5
- HTML5
- CSS3
- JavaScript
- Cookie Authentication

---

# 🏗 Architecture

The project follows **N-Tier Architecture**

```
Presentation Layer (PL)

        ↓

Business Logic Layer (BLL)

        ↓

Data Access Layer (DAL)

        ↓

SQL Server
```

The project also implements:

- Repository Pattern
- Unit Of Work Pattern
- Dependency Injection

---

# 📂 Project Structure

```
GymSystemManagement

│

├── GymSystemManagement.PL

├── GymSystemManagement.BLL

├── GymSystemManagement.DAL

└── Database
```

---

# 📷 Screenshots

## Login

(Add Screenshot Here)

---

## Dashboard

(Add Screenshot Here)

---

## Members

(Add Screenshot Here)

---

## Trainers

(Add Screenshot Here)

---

## Sessions

(Add Screenshot Here)

---

## Memberships

(Add Screenshot Here)

---

## Booking

(Add Screenshot Here)

---

# ⚙️ Installation

## Clone Repository

```bash
git clone https://github.com/Ahmed-kh10/UpdateGymSystem.git
```

Open the solution using Visual Studio.

---

## Configure Database

Update your connection string inside

```
appsettings.json
```

Example

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=GymSystemManagement;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## Apply Migration

```powershell
Update-Database
```

or

```bash
dotnet ef database update
```

---

## Run Project

Press

```
F5
```

or

```
Ctrl + F5
```

---

# 🔐 Login Credentials

Current Demo Credentials

```
Username

admin
```

```
Password

123456
```

---

# 🎯 Future Improvements

- Identity Authentication
- Role Management
- Email Verification
- Payment Integration
- QR Code Attendance
- Reports & Analytics
- Notifications
- Dashboard Charts

---

# 👨‍💻 Developed By

**Ahmed Khaled**

ASP.NET Core MVC Developer

GitHub

https://github.com/Ahmed-kh10

---

# ⭐ If you like this project

Give it a ⭐ on GitHub.
