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
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public List<int> Durations { get; set; } = new List<int>();

        public WorkoutPlan(DateTime date)
        {
            Date = date;
        }

        public void AddExercise(Exercise exercise, int duration)
        {
            Exercises.Add(exercise);
            Durations.Add(duration);
        }

        public int TotalCaloriesBurned(double userWeight)
        {
            double total = 0;
            for (int i = 0; i < Exercises.Count; i++)
            {
                total += Exercises[i].CalculateCaloriesBurned(userWeight, Durations[i]);
            }
            return (int)total;
        }
    }
}




