using EmployeeManagerApp.Models;
using EmployeeManagerApp.Services;
using System;

namespace EmployeeManagerApp.Extensions
{
    public class DepartmentMenu : IMenuExtension
    {
        private readonly DepartmentRepository _deptRepo;

        public string Title => "Manage Departments";

        public DepartmentMenu()
        {
            _deptRepo = new DepartmentRepository();
        }

        public void Show()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\nDepartment Management");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. View Departments");
                Console.WriteLine("3. Update Department");
                Console.WriteLine("4. Delete Department");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        ViewDepartments();
                        break;
                    case "3":
                        UpdateDepartment();
                        break;
                    case "4":
                        DeleteDepartment();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private void AddDepartment()
        {
            try
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                _deptRepo.Add(new Department { DepartmentId = id, Name = name });
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numbers for ID.");
            }
        }

        private void ViewDepartments()
        {
            var departments = _deptRepo.GetAll();
            if (departments.Any())
            {
                foreach (var d in departments)
                    Console.WriteLine($"{d.DepartmentId}: {d.Name}");
            }
            else
            {
                Console.WriteLine("No departments found.");
            }
        }

        private void UpdateDepartment()
        {
            try
            {
                Console.Write("ID to update: ");
                int uid = int.Parse(Console.ReadLine());
                Console.Write("New Name: ");
                string newName = Console.ReadLine();

                if (!_deptRepo.Update(uid, new Department { Name = newName }))
                    Console.WriteLine("Department not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numbers for ID.");
            }
        }

        private void DeleteDepartment()
        {
            try
            {
                Console.Write("ID to delete: ");
                int did = int.Parse(Console.ReadLine());

                if (!_deptRepo.Delete(did))
                    Console.WriteLine("Department not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numbers for ID.");
            }
        }
    }
}