using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{ 
    public class WorkoutPlan


    {
        public DateTime Date { get; set; }
        public List<Exercise> exercises = new List<Exercise>();
        public List<double> durations = new List<double>();
        public bool AddExercise(Exercise exercise, double duration)
        {
            bool valid = true;
            if (exercise == null)
            {
                Console.WriteLine("Exercise cannot be null");
                valid = false;
            }
            if (duration <= 0)
            {
                Console.WriteLine("Duration must be positive");
                valid = false;
            }
            if (!valid)
            {
                return false;
            }
            exercises.Add(exercise);
            durations.Add(duration);
            return true;

        }


    }
}