using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{
    public class Exercise
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double CaloriesBurnedPerMin { get; set; }

        public bool SetExercise(string name, string type, double caloriesBurnedPerMin) // ميثود مش موجودة فى الكلاس دى بس ممكن نستخدمها لأخذ البيانات من اليوزر والتأكد منها 
        {
            bool valid = true;
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Type cannot be empty ");
                valid = false;
            }
            if (type != "yoga" && type != "strength" && type != "cardio")
            {
                Console.WriteLine("Type must be : Cardio, Strength, or Yoga");
                valid = false;
            }
            if (caloriesBurnedPerMin <= 0)
            {
                Console.WriteLine("Calories per minutes must be positive");
                valid = false;
            }
            if (!valid)
            {
                return false;
            }
            Name = name;
            Type = type;
            CaloriesBurnedPerMin = caloriesBurnedPerMin;
            return true;
        }
        public double caloriesBurnedBasedOnDuration(double durationInMin)
        {
            if (durationInMin <= 0)
            {
                Console.WriteLine("duration must be positive");
                return 0;
            }
            return durationInMin * CaloriesBurnedPerMin;

        }





    }
}