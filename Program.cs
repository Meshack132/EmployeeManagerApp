using EmployeeManagerApp.UI;
using EmployeeManagerApp.Extensions;

var menu = new Menu();
menu.AddExtension(new DepartmentMenu()); // Now works without exceptions
menu.Run();