using EntityFrameworkDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDBFirst.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        void AddEmployee(Employee Employee);
    }
}
