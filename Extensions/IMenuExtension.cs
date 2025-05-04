using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerApp.Extensions
{
    public interface IMenuExtension
    {
        string Title { get; }
        void Show();
    }
}
