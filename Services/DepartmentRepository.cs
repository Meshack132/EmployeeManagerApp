using System.Collections.Generic;
using EmployeeManagerApp.Models;
using System.Linq;

namespace EmployeeManagerApp.Services
{
    public class DepartmentRepository
    {
        private readonly List<Department> _departments = new();

        public void Add(Department department) => _departments.Add(department);

        public List<Department> GetAll() => _departments;

        public bool Update(int id, Department updated)
        {
            var dept = _departments.FirstOrDefault(d => d.DepartmentId == id);
            if (dept == null) return false;
            dept.Name = updated.Name;
            return true;
        }

        public bool Delete(int id)
        {
            var dept = _departments.FirstOrDefault(d => d.DepartmentId == id);
            if (dept == null) return false;
            _departments.Remove(dept);
            return true;
        }
    }
}
