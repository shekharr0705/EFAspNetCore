using EntityFrameworkDBFirst.Models;
using EntityFrameworkDBFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDBFirst.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IDepartmentRepository _departmentRepo;

        public EmployeeController(IEmployeeRepository employeeRepo,IDepartmentRepository departmentRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
        }
        public IActionResult Index()
        {
            var employees = _employeeRepo.GetAllEmployee();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var departments = _departmentRepo.GetAllDepartments();
            ViewBag.Departments = departments;
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _employeeRepo.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
