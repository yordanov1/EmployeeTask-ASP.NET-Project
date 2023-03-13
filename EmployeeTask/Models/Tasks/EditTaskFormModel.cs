namespace EmployeeTask.Models.Tasks
{
    using System;

    public class EditTaskFormModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
