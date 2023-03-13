namespace EmployeeTask.Models.Tasks
{
    using EmployeeTask.Data.Models;
    using System;

    public class TaskModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int EmployeeId { get; set; }

        public bool IsCompleted { get; set; }
    }
}
