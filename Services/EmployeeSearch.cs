using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagerApp.Models;

namespace EmployeeManagerApp.Services
{
    public class EmployeeSearch
    {
        public List<Employee> SearchByName(List<Employee> employees, string name)
        {
            return employees.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

