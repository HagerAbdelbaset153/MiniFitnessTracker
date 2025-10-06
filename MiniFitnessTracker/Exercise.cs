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
        

        public Exercise(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public Exercise() { } // عشان نقدر نستخدمها في LogWorkout قبل ما نحدد القيم

        //  دالة لحساب السعرات حسب نوع التمرين ووزن المستخدم ومدة التمرين
        public double CalculateCaloriesBurned(double weight, int duration)
        {
            double factor = 0; // نستخدم معامل من قيم MET × 0.0175

            switch (Type.ToLower())
            {
                case "cardio":
                    factor = 0.14;   // MET ~ 8
                    break;
                case "strength":
                    factor = 0.105;  // MET ~ 6
                    break;
                case "yoga":
                    factor = 0.0525; // MET ~ 3
                    break;
                case "flexibility":
                    factor = 0.043;  // MET ~ 2.5
                    break;
                case "weightloss":
                    factor = 0.175;  // MET ~ 10
                    break;
                case "abs":
                    factor = 0.0875; // MET ~ 5
                    break;
            }

            return factor * weight * duration; // المعادلة الأساسية
        }
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



