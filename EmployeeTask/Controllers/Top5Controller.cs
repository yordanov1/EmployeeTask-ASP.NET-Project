namespace EmployeeTask.Controllers
{
    using EmployeeTask.Data;
    using EmployeeTask.Models.Employees;
    using EmployeeTask.Models.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class Top5Controller : Controller
    {
        private readonly EmployeeTaskDbContext data;

        public Top5Controller(EmployeeTaskDbContext data)
        {
            this.data = data;
        }


        public IActionResult TakeTop5()
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
                CountCompletedTasks = x.CountCompletedTasks,
                
                Tasks = x.Tasks.Select(p => new TaskModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    DueDate = p.DueDate,
                    IsCompleted = p.IsCompleted,
                }).ToList()
            }).ToList();
           

            var orderedEmployees = employees.OrderByDescending(x => x.CountCompletedTasks).Take(5).ToList();

            return View(orderedEmployees);
        }
    }
}
