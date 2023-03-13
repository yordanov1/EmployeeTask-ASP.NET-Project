﻿namespace EmployeeTask.Models.Tasks
{
    using System;

    public class TaskFormModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDete { get; set; }

        public bool IsCompleted { get; set; }

        public int EmployeeId { get; set; }
    }
}
