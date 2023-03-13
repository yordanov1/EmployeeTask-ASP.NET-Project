namespace EmployeeTask.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            CountCompletedTasks = 0;
            Tasks = new List<Task>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public DateTime BirthDate { get; set; }

        public int CountCompletedTasks { get; set; } 

        public double Salary { get; set; }

        public List<Task> Tasks { get; set; } 
    }
}
