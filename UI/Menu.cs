using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagerApp.Models;
using EmployeeManagerApp.Services;
using EmployeeManagerApp.Extensions;

namespace EmployeeManagerApp.UI
{
    public class Menu
    {
        private readonly EmployeeRepository _repo = new();
        private readonly EmployeeSearch _search = new();
        private readonly List<IMenuExtension> _extensions = new();

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nEmployee Manager");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Search by Name");
                Console.WriteLine("5. View All Employees");
                Console.WriteLine("6. Count Employees");
                Console.WriteLine("7. Manage Departments");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddEmployee(); break;
                    case "2":
                        UpdateEmployee(); break;
                    case "3":
                        DeleteEmployee(); break;
                    case "4":
                        SearchEmployee(); break;
                    case "5":
                        ListEmployees(); break;
                    case "6":
                        Console.WriteLine($"Total Employees: {_repo.Count()}"); break;
                    case "7":
                        ShowDepartmentMenu(); break;
                    case "0":
                        exit = true; break;
                    default:
                        Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        // Single implementation of AddExtension that uses IMenuExtension
        public void AddExtension(IMenuExtension extension)
        {
            if (extension == null)
                throw new ArgumentNullException(nameof(extension));

            _extensions.Add(extension);
        }

        private void ShowDepartmentMenu()
        {
            var deptMenu = _extensions.FirstOrDefault(e => e is DepartmentMenu);
            if (deptMenu != null)
            {
                deptMenu.Show();
            }
            else
            {
                Console.WriteLine("Department management is not available.");
            }
        }

        private void AddEmployee()
        {
            try
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Surname: ");
                string surname = Console.ReadLine();
                Console.Write("Dept ID: ");
                int dept = int.Parse(Console.ReadLine());
                Console.Write("Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());

                _repo.Add(new Employee
                {
                    EmployeeId = id,
                    Name = name,
                    Surname = surname,
                    DepartmentId = dept,
                    Salary = salary
                });
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter ID to update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Surname: ");
                string surname = Console.ReadLine();
                Console.Write("Dept ID: ");
                int dept = int.Parse(Console.ReadLine());
                Console.Write("Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());

                if (!_repo.Update(id, new Employee
                {
                    Name = name,
                    Surname = surname,
                    DepartmentId = dept,
                    Salary = salary
                }))
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please try again.");
            }
        }

        private void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                if (!_repo.Delete(id))
                    Console.WriteLine("Employee not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please try again.");
            }
        }

        private void SearchEmployee()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();
            var results = _search.SearchByName(_repo.GetAll(), name);

            if (results.Any())
            {
                foreach (var e in results)
                    Console.WriteLine($"{e.EmployeeId}: {e.Name} {e.Surname} - Dept {e.DepartmentId}, Salary {e.Salary:C}");
            }
            else
            {
                Console.WriteLine("No employees found matching that name.");
            }
        }

        private void ListEmployees()
        {
            var employees = _repo.GetAll();
            if (employees.Any())
            {
                foreach (var e in employees)
                    Console.WriteLine($"{e.EmployeeId}: {e.Name} {e.Surname} - Dept {e.DepartmentId}, Salary {e.Salary:C}");
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }
    }
}