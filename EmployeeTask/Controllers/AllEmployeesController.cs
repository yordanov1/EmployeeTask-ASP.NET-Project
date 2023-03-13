namespace EmployeeTask.Controllers
{
    using System.Linq;
    using EmployeeTask.Data;
    using EmployeeTask.Data.Models;
    using EmployeeTask.Models.Employees;
    using EmployeeTask.Models.Tasks;
    using Microsoft.AspNetCore.Mvc;
    

    public class AllEmployeesController : Controller
    {
        private readonly EmployeeTaskDbContext data;

        public AllEmployeesController(EmployeeTaskDbContext data)
        {
            this.data = data;
        }


         public IActionResult All()
         {
            var employees = data.Employees.Select(x => new AllEmployeesFormModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                BirthDate = x.BirthDate,
                Salary = x.Salary,
                Tasks = x.Tasks.Select(p => new TaskModel
                {      
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    DueDate = p.DueDate,
                    IsCompleted = p.IsCompleted,
                }).ToList()   
            }).ToList();
           
            return View(employees);
         }


        public IActionResult AddTask()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddTask(int id, AddTaskFormModel task)
        {
            var employee = data.Employees.FirstOrDefault(x => x.Id == id);

            Task newTask = new Task
            {
                Title = task.Title,
                Description= task.Description, 
                Employee = employee,
                DueDate= task.DueDate,
                IsCompleted = false
            };

            employee.Tasks.Add(newTask);

            this.data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }        
    }
}
