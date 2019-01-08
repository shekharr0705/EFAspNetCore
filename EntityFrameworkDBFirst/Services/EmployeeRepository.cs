using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkDBFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace EntityFrameworkDBFirst.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyContext _dbContext;

        public EmployeeRepository(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddEmployee(Employee employee)
        {
            var nameParam = new SqlParameter("@Name", employee.Name);
            //Need to use below parameter method ,since default type is string
            var departmentIdParam = new SqlParameter()
            {
                ParameterName = "@Department_ID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = employee.DepartmentId
            };
            var numberOfRowsEffected = _dbContext.Database.ExecuteSqlCommand("AddEmpployee @Name,@Department_ID", nameParam, departmentIdParam);
            _dbContext.Employee.Add(employee);
            _dbContext.SaveChanges();

            #region Update Test
            //var departmentIdParam = new SqlParameter()
            //{
            //    ParameterName = "@DepartmentId",
            //    SqlDbType = System.Data.SqlDbType.Int,
            //    Direction = System.Data.ParameterDirection.Input,
            //    Value = employee.DepartmentId
            //};
            //var numberOfRowsEffected = _dbContext.Database.ExecuteSqlCommand("AddEmpployee @Name,@DepartmentId", nameParam, departmentIdParam);
            #endregion
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            //return _dbContext.Employee.ToList();
            return _dbContext.Employee.FromSql("GetAllEmployee").ToList();
        }
    }
}
