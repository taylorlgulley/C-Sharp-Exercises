using System;
using System.Collections.Generic;

namespace classes {
    public class Employee {

        public string FirstName;

        public string LastName;
        public string Title;
        public DateTime StartDate;
        public Employee(string firstName, string lastName, string title, DateTime startDate) {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            StartDate = startDate;
        }
    }
}