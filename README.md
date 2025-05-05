Here’s the updated `README.md` content that you can add to your GitHub repository:

---

````markdown
# EmployeeManagerApp

A simple C# Console App for managing employees, built using the SOLID principles for clean and maintainable code.

---

## 📌 Features

- Add, update, delete, and list employees
- Search employees by name
- Count total employees
- Department management via extensions (Open/Closed Principle)

---

## 🧱 SOLID Principles Applied

### ✅ S – Single Responsibility Principle (SRP)

Each class has a single clear responsibility:

- `EmployeeRepository` — Handles storing and managing employee data.
- `EmployeeSearch` — Performs name-based employee searches.
- `Menu` — Manages user interaction and menus.
- `DepartmentMenu` (extension) — Adds department management without changing the core code.

This separation ensures low coupling and high cohesion.

---

### ✅ O – Open/Closed Principle (OCP)

The app supports extensibility via the `IMenuExtension` interface. New features like managing departments can be added without modifying the existing `Menu` class.

- You can add new menu options (e.g. `DepartmentMenu`) by registering them as extensions.
- The main logic remains untouched, making it easy to scale and maintain.

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/Meshack132/EmployeeManagerApp.git
````

2. Open in Visual Studio or any C# IDE.
3. Build and run the console app.

---

## 🔧 Tech Stack

* C#
* .NET
* Console App

---

## 📚 License

MIT License

---

## 🙌 Author

[Meshack Mthimkhulu](https://github.com/Meshack132)

```

---

