using EmployeeWebApp.Models;
//using MyProject;
namespace EmployeeWebApp.Business
{
    public class EmployeeBusiness
    {
        private static List<Employee> _employees = new List<Employee>();

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _employees.Find(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.JoinDate = employee.JoinDate;
            }
        }

        public Employee GetEmployeeWithNthHighestSalary(int n)
        {
            return _employees.OrderByDescending(e => e.Salary).Skip(n - 1).FirstOrDefault();
        }

        public List<Employee> GetEmployeesJoinedInRange(DateTime startDate, DateTime endDate)
        {
            return _employees.Where(e => e.JoinDate >= startDate && e.JoinDate <= endDate).ToList();
        }

    }
}
