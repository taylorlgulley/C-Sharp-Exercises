using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Student
    {
        public Student(string firstName, string lastName, string slackHandle, Cohort cohort)
        {
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slackHandle;
            Cohort = cohort;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }
        public Cohort Cohort;
        public List<Exercise> StudentExercises = new List<Exercise>();
    }
}