using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Cohort
    {
        public Cohort(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public List<Student> ListOfStudents = new List<Student>();
        public List<Instructor> ListOfInstructors = new List<Instructor>();
    }
}