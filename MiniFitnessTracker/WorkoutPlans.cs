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
        public List<Exercise> Exercises { get; set; }
        public Dictionary<Exercise, int> ExerciseDurations { get; set; } // in minutes
        public WorkoutPlan(DateTime date)
        {
            Date = date;
            Exercises = new List<Exercise>();
            ExerciseDurations = new Dictionary<Exercise, int>();
        }
        public void AddExercise(Exercise ex, int duration)
        {
            Exercises.Add(ex);
            ExerciseDurations[ex] = duration;
        }
        public void RemoveExercise(Exercise ex)
        {
            if (Exercises.Contains(ex))
            {
                Exercises.Remove(ex);
                ExerciseDurations.Remove(ex);
            }
        }
        public double CalculateDailyCalories(double userWeight)
        {
            double total = 0;
            foreach (var ex in Exercises)
            {
                int duration = ExerciseDurations[ex];
                total += ex.CalculateCalories(duration, userWeight);
            }
            return total;
        }

    }
}
