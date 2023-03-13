namespace EmployeeTask.Controllers
{
    using EmployeeTask.Data;
    using EmployeeTask.Models.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class TasksController : Controller
    {

        private readonly EmployeeTaskDbContext data;

        public TasksController(EmployeeTaskDbContext data)
        {
            this.data = data;
        }


        public IActionResult TaskView(int id, int ide)
        {
            var taskId = data.Tasks.FirstOrDefault(x => x.Id == id);
            var employee = data.Employees.FirstOrDefault(x => x.Id == ide);

            var taskForm = new TaskFormModel
            {
                Id = taskId.Id,
                Title = taskId.Title,
                Description = taskId.Description,
                DueDete = taskId.DueDate,
                IsCompleted = taskId.IsCompleted,
                EmployeeId = employee.Id,
            };

            return View(taskForm);
        }


        public IActionResult Delete(int id, int ide)
        {
            var taskDelete = data.Tasks.FirstOrDefault(x => x.Id == id);
            var employee = data.Employees.FirstOrDefault(x => x.Id == ide);

            if (taskDelete.IsCompleted == true)
            {
                employee.CountCompletedTasks--;
            }
            

            data.Tasks.Remove(taskDelete);

            data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }

        public IActionResult EditTask(int id)
        {
            var task = data.Tasks.FirstOrDefault(x => x.Id == id);

            var taskForm = new EditTaskFormModel
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted
            };

            return View(taskForm);
        }

        [HttpPost]
        public IActionResult EditTask(int id, EditTaskFormModel formModel)
        {

            var task = data.Tasks.FirstOrDefault(x => x.Id == id);

            task.Title = formModel.Title;  
            task.Description = formModel.Description;
            task.DueDate = formModel.DueDate;

            data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }


        public IActionResult Return()
        {
            return RedirectToAction("All", "AllEmployees");
        }


        public IActionResult Complete(int id, int ide)
        {
            var task = data.Tasks.FirstOrDefault(x => x.Id == id);
            var employee = data.Employees.FirstOrDefault(x => x.Id == ide);

            employee.CountCompletedTasks++;
            task.IsCompleted = true;


            data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }

        public IActionResult Restart(int id, int ide)
        {
            var task = data.Tasks.FirstOrDefault(x => x.Id == id);
            var employee = data.Employees.FirstOrDefault(x => x.Id == ide);

            employee.CountCompletedTasks--;
            task.IsCompleted = false;

            data.SaveChanges();

            return RedirectToAction("All", "AllEmployees");
        }
    }
}
