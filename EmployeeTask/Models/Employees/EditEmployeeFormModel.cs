﻿namespace EmployeeTask.Models.Employees
{
    using System;

    public class EditEmployeeFormModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public double Salary { get; set; }
    }
}
