
using MiniFitnessTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    internal class ProgressTracker
    {
        public double WeeklyCalories { get; set; }
        public double TotalWorkoutTime { get; set; }
        public List<string> ExerciseStats = new List<string>();

        public void Displayweeklystatistics(List<WorkoutPlan> workoutPlans)
        {
            DateTime OneWeekAgo = DateTime.Now.AddDays(-7);

            ExerciseStats.Clear();
            WeeklyCalories = 0;
            TotalWorkoutTime = 0;
            foreach (var plan in workoutPlans)
            {
                if (plan.Date >= OneWeekAgo)
                {
                    for (int i = 0; i < plan.exercises.Count; i++)
                    {
                        var exercise = plan.exercises[i];
                        var duration = plan.durations[i];
                        double calories = exercise.caloriesBurnedBasedOnDuration(duration);
                        WeeklyCalories += calories;
                        TotalWorkoutTime += duration;
                        if ((!ExerciseStats.Contains(exercise.Type.ToLower())))
                        {
                            ExerciseStats.Add(exercise.Type.ToLower());
                        }
                    }
                }

            }
            Console.WriteLine("----------------Weekly Statistics--------------");
            Console.WriteLine($" Total WorkOut Time {TotalWorkoutTime} mins");
            Console.WriteLine($"Total Calories Burned {WeeklyCalories} cal");
            Console.WriteLine($"Exercise Type This Week ");
            foreach (var type in ExerciseStats)
            {
                Console.WriteLine(" -" + type);
            }


        }
        public void DisplayDailyStatistics(List<WorkoutPlan> workoutPlans, DateTime date)
        {
            WorkoutPlan dayplan = null;
            foreach (var plan in workoutPlans)
            {
                if (plan.Date.Date == date.Date)
                {
                    dayplan = plan;
                    break;
                }

            }
            if (dayplan == null)
            {
                Console.WriteLine($"No Workout logged for {date.ToShortDateString()} ");
                return;
            }
            double dailycalories = 0;
            double dailytime = 0;
            List<string> ExerciseType = new List<string>();
            for (int i = 0; i < dayplan.exercises.Count; i++)
            {
                var exercise = dayplan.exercises[i];
                var duration = dayplan.durations[i];
                double calories = exercise.caloriesBurnedBasedOnDuration(duration);
                dailycalories += calories;
                dailytime += duration;
                if ((!ExerciseType.Contains(exercise.Type.ToLower())))
                {

                    ExerciseType.Add(exercise.Type.ToLower());
                }
            }
            Console.WriteLine($"------------Daily Statistics for {date.ToShortDateString()}----------");
            Console.WriteLine($"Total Workout Time {dailytime} mins");
            Console.WriteLine($" Total Calories Burned  {dailycalories} cal");
            Console.WriteLine(" Exercise Types");
            foreach (var type in ExerciseType)
            {
                Console.WriteLine(" -" + type);
            }
        }
    }
}
