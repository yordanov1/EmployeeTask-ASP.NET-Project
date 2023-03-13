namespace EmployeeTask.Controllers
{
    using System;
    using System.Linq;
    using EmployeeTask.Data;
    using EmployeeTask.Data.Models;
    using EmployeeTask.Models.Employees;
    using Microsoft.AspNetCore.Mvc;    
    using System.Collections.Generic;
    

    public class EmployeesController : Controller
    {

        private readonly EmployeeTaskDbContext data;

        public EmployeesController(EmployeeTaskDbContext data)
        {
            this.data = data;
        }

        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeFormModel employee)
        {
            var employeeToAdd = new Employee
            {
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                BirthDate = employee.BirthDate,
                Salary = employee.Salary,
            };

            this.data.Add(employeeToAdd);

            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Delete(int id)
        {
            var employeeDelete = data.Employees.FirstOrDefault(x => x.Id == id);

            data.Employees.Remove(employeeDelete);

            data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }


        public IActionResult Edit(int id)
        {
            var employeeId = data.Employees.FirstOrDefault(x => x.Id == id);

            var employeeForm = new EditEmployeeFormModel
            {
                FirstName = employeeId.FirstName,
                MiddleName = employeeId.MiddleName,
                LastName = employeeId.LastName,
                Email = employeeId.Email,
                PhoneNumber = employeeId.PhoneNumber,
                BirthDate = employeeId.BirthDate,
                Salary = employeeId.Salary
            };

            return View(employeeForm);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditEmployeeFormModel employeeForm)
        {

            var employeeId = data.Employees.FirstOrDefault(x => x.Id == id);

            employeeId.FirstName = employeeForm.FirstName;
            employeeId.MiddleName = employeeForm.MiddleName;
            employeeId.LastName = employeeForm.LastName;
            employeeId.Email = employeeForm.Email;
            employeeId.PhoneNumber = employeeForm.PhoneNumber;
            employeeId.BirthDate = employeeForm.BirthDate;
            employeeId.Salary = employeeForm.Salary;

            data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }
    }
}
