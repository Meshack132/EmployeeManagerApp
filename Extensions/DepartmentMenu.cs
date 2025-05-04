using EmployeeManagerApp.Models;
using EmployeeManagerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerApp.Extensions
{
    
        public class DepartmentMenu : IMenuExtension
        {
            private readonly DepartmentRepository _deptRepo = new();

            public string Title => "Manage Departments";

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
                            Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
                            Console.Write("Name: "); string name = Console.ReadLine();
                            _deptRepo.Add(new Department { DepartmentId = id, Name = name });
                            break;
                        case "2":
                            foreach (var d in _deptRepo.GetAll())
                                Console.WriteLine($"{d.DepartmentId}: {d.Name}");
                            break;
                        case "3":
                            Console.Write("ID to update: "); int uid = int.Parse(Console.ReadLine());
                            Console.Write("New Name: "); string newName = Console.ReadLine();
                            if (!_deptRepo.Update(uid, new Department { Name = newName }))
                                Console.WriteLine("Not found.");
                            break;
                        case "4":
                            Console.Write("ID to delete: "); int did = int.Parse(Console.ReadLine());
                            if (!_deptRepo.Delete(did)) Console.WriteLine("Not found.");
                            break;
                        case "0": back = true; break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                }
            }
        }
    }
