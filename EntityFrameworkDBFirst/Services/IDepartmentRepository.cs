using EntityFrameworkDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDBFirst.Services
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(Department department);
    }
}
