namespace EmployeeTask.Models.Employees
{
    using EmployeeTask.Models.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AllEmployeesFormModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }

        public int CountCompletedTasks { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}
