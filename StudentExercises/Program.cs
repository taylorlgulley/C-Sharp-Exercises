using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {
            // Create 4, or more, exercises.
            Exercise loops = new Exercise("Loops", "C#");
            Exercise localStorage = new Exercise("Local Storage", "Javascript");
            Exercise modules = new Exercise("Modularization", "Javascript");
            Exercise props = new Exercise("Props", "React");
            // Create 3, or more, cohorts.
            Cohort day26 = new Cohort("Day Cohort 26");
            Cohort day27 = new Cohort("Day Cohort 27");
            Cohort day28 = new Cohort("Day Cohort 28");
            Cohort night8 = new Cohort("Evening Cohort 8");
            // Create 4, or more, students and assign them to one of the cohorts.
            Student taylor = new Student("Taylor", "Gulley", "taylor1", day27);
            Student mark = new Student("Mark", "Hale", "mark1", day27);
            Student vik = new Student("Sathvik", "Reddy", "vik1", day26);
            Student nolan = new Student("Nolan", "Little", "nolan1", day28);
            Student jon = new Student("Jon", "Snow", "King of the North", night8);
            day27.ListOfStudents.Add(taylor);
            day27.ListOfStudents.Add(mark);
            day26.ListOfStudents.Add(vik);
            day28.ListOfStudents.Add(nolan);
            night8.ListOfStudents.Add(jon);
            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor steve = new Instructor("Steve", "Brownlee", "coach", day27);
            Instructor meg = new Instructor("Meg", "Ducharme", "meg", day27);
            Instructor kimmy = new Instructor("Kimmy", "Bird", "kimmy", day27);
            Instructor andy = new Instructor("Andy", "Collins", "andy", day27);
            day27.ListOfInstructors.Add(steve);
            day27.ListOfInstructors.Add(meg);
            day27.ListOfInstructors.Add(kimmy);
            day27.ListOfInstructors.Add(andy);
            // Have each instructor assign 2 exercises to each of the students.
            steve.AssignExercise(taylor, modules);
            steve.AssignExercise(taylor, props);
            meg.AssignExercise(mark, modules);
            meg.AssignExercise(mark, loops);
            kimmy.AssignExercise(vik, props);
            kimmy.AssignExercise(vik, localStorage);
            andy.AssignExercise(nolan, localStorage);
            andy.AssignExercise(nolan, loops);
            steve.AssignExercise(taylor, props);

            List<Student> students = new List<Student>()
            {
                taylor, mark, vik, nolan, jon
            };
            List<Exercise> exercises = new List<Exercise>()
            {
                loops, localStorage, modules, props
            };
            // can reference probes and planets for this, do something like  loop over the exercises then loop over the students to match up who is working on what like Modularization : Taylor, Mark
            // foreach (Student student in students)
            // {
            //     Console.WriteLine($"{student.FirstName} {student.LastName} is working on {student.StudentExercises[0].Name} and {student.StudentExercises[1].Name}");
            // }
            foreach (Exercise exercise in exercises)
            {
                List<string> matchingExercises = new List<string>();
                foreach (Student student in students)
                {
                    if (student.StudentExercises.Contains(exercise)) {
                        matchingExercises.Add(student.FirstName);
                    }
                }
                Console.WriteLine($"{exercise.Name} is assigned to: {String.Join(", ", matchingExercises)}");
            }
            // Student Exercises Part 2
            List<Instructor> instructors = new List<Instructor>()
            {
                steve, meg, kimmy, andy
            };
            List<Cohort> cohorts = new List<Cohort>()
            {
                day26, day27, day28, night8
            };
            //List exercises for the JavaScript language by using the Where() LINQ method.
            IEnumerable<Exercise> javascriptExercises = from exercise in exercises
                where exercise.Language == "Javascript"
                select exercise;
            //List students in a particular cohort by using the Where() LINQ method.
            List<Student> cohort27Students = (from student in students
                where student.Cohort == day27
                select student).ToList();
            //List instructors in a particular cohort by using the Where() LINQ method.
            List<Instructor> cohort27Instructors = instructors.Where(i => i.Cohort == day27).ToList();
            //Sort the students by their last name.
            List<Student> sortedStudents = (from student in students
                orderby student.LastName
                select student).ToList();
            //Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            List<Student> studentWithoutExercises = (from student in students
                where student.StudentExercises.Count == 0
                select student
                ).ToList();
            // Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
            var studentWithMostExercises = (from student in students
                select new {
                    FirstName = student.FirstName,
                    Exercises = student.StudentExercises.Count()
                }).OrderByDescending(s => s.Exercises)
                .Take(1).ToList()[0];
            // How many students in each cohort?
            // GroupBy gives you a collection of groups - each group has something that it's being grouped by (the key). The group itself is the list of all of the values of the group. Returns a collection of groups.
            // collection of groups (numberOfStudentsInEachCohort)
            // METHOD WAY
            var numberOfStudentsInEachCohort = students.GroupBy(c => c.Cohort.Name);
            // looks at every group of students
            foreach (var studentGroup in numberOfStudentsInEachCohort)
            {
                // key is the thing you grouped by
                // Console.WriteLine($"{studentGroup.Key} has {studentGroup.Count()} students");
            }

            // SQL/QUERY WAY
            var totalStudents = from student in students
                group student by student.Cohort into sorted
                select new {
                    Cohort = sorted.Key,
                    Students = sorted.ToList()
                };
                foreach (var total in totalStudents)
                {
                    Console.WriteLine($"Cohort {total.Cohort.Name} has {total.Students.Count()} students");
                }

            Console.WriteLine ("Hello World!");
        }
    }
}