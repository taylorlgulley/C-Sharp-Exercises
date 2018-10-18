using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Exercise
    {
        public Exercise(string name, string language)
        {
            ExerciseName = name;
            ExerciseLanguage = language;
        }
        public string ExerciseName { get; set; }
        public string ExerciseLanguage { get; set; }
        // This is the default constructor for Dapper so it doesn't need parameters
        public Exercise(){}
    }
}