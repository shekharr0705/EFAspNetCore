using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkDBFirst.Models;

namespace EntityFrameworkDBFirst.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyContext _dbContext;

        public DepartmentRepository(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _dbContext.Department.ToList();
        }
    }
}
