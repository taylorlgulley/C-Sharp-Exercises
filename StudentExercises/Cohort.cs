using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Cohort
    {
        public Cohort(string name)
        {
            CohortName = name;
        }
        public string CohortName { get; set; }
        public List<Student> ListOfStudents = new List<Student>();
        public List<Instructor> ListOfInstructors = new List<Instructor>();
        public Cohort(){}
    }
}