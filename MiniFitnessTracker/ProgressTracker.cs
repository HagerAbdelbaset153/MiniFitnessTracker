using MiniFitnessTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MiniFitnessTracker
{
    public class ProgressTracker
    {
        public void Displayweeklystatistics(User currentUser)
        {
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No user logged in.");
                Console.ResetColor();
                return;
            }

            var workoutPlans = currentUser.WorkoutPlans;

            if (workoutPlans == null || workoutPlans.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No workout data available.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==== Weekly Progress ====");
            Console.ResetColor();

            var last7days = workoutPlans
                .Where(p => (DateTime.Now - p.Date).TotalDays <= 7)
                .ToList();

            if (last7days.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No workouts in the last 7 days.");
                Console.ResetColor();
                return;
            }

            double userWeight = currentUser.Weight;
            int weeklyTotal = 0;

            foreach (var plan in last7days)
            {
                int dayTotal = plan.TotalCaloriesBurned(userWeight);
                weeklyTotal += dayTotal;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{plan.Date.ToShortDateString()} - {dayTotal} calories burned");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total calories burned in last 7 days: {weeklyTotal}");
            Console.ResetColor();
        }
    }
}
   










