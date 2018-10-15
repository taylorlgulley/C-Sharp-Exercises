using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Instructor
    {
        public Instructor(string firstName, string lastName, string slackHandle, Cohort cohort)
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
        public void AssignExercise(Student student, Exercise exercise) {
            student.StudentExercises.Add(exercise);
        }
    }
}