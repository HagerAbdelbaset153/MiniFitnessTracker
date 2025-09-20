using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MiniFitnessTracker
{

    public enum WorkoutCategory
    {
        Cardio,
        Strength,
        Yoga,
        Flexibility,
        WeightLoss,
        Abs
    }


    public class Exercise
    {
        public string Name { get; set; }
        public string Type { get; set; } // Cardio / Strength / Yoga
        public double CaloriesBurnedPerMin { get; set; }

        public Exercise(string name, string type, double caloriesBurnedPerMin)
        {
            Name = name;
            Type = type;
            CaloriesBurnedPerMin = caloriesBurnedPerMin;
        }

        public Exercise() { } // عشان نقدر نستخدمها في LogWorkout قبل ما نحدد القيم





    }




    public static class WorkoutRepository
    {
        public static Dictionary<WorkoutCategory, List<string>> Workouts = new Dictionary<WorkoutCategory, List<string>>()
    {
        { WorkoutCategory.Cardio, new List<string> { "Running", "Cycling", "Jump Rope" } },
        { WorkoutCategory.Strength, new List<string> { "Push Ups", "Squats", "Deadlifts" } },
        { WorkoutCategory.Yoga, new List<string> { "Sun Salutation", "Tree Pose", "Warrior Pose" } },
        { WorkoutCategory.Flexibility, new List<string> { "Stretching", "Hamstring Stretch", "Shoulder Stretch" } },
        { WorkoutCategory.WeightLoss, new List<string> { "HIIT", "Burpees", "Mountain Climbers" } },
        { WorkoutCategory.Abs, new List<string> { "Plank", "Crunches", "Leg Raises" } }
    };





    }



}



