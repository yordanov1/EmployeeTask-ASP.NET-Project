namespace EmployeeTask.Models.Employees
{
    using EmployeeTask.Data.Models;
    using System;

    public class AddTaskFormModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public int EmployeeId { get; set; }         
    }
}
