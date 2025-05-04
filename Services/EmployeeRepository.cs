using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagerApp.Models;

namespace EmployeeManagerApp.Services
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public void Add(Employee employee) => _employees.Add(employee);

        public bool Update(int id, Employee updated)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null) return false;

            emp.Name = updated.Name;
            emp.Surname = updated.Surname;
            emp.DepartmentId = updated.DepartmentId;
            emp.Salary = updated.Salary;
            return true;
        }

        public bool Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null) return false;
            _employees.Remove(emp);
            return true;
        }

        public List<Employee> GetAll() => _employees;

        public int Count() => _employees.Count;
    }
}
