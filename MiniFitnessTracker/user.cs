using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MiniFitnessTracker
{
    public class User
    {
        public string Name { get; set; }    
        public int Age { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm
        public List<WorkoutPlan> WorkoutPlans { get; set; }= new List<WorkoutPlan>();


        public User(string name, int age, double weight, double height)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
           
        }



        public string CalculateBMI()
        {
            double heightInMeters = Height / 100; // لأن الطول متخزن بالـ cm
            double bmi = Weight / (heightInMeters * heightInMeters);

            string category;
            if (bmi < 18.5) category = "Underweight";
            else if (bmi < 25) category = "Normal";
            else if (bmi < 30) category = "Overweight";
            else category = "Obese";

            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"Your BMI is {bmi:F2} ({category})";

        }



        public double? WeightGoal { get; set; } // null لو مفيش هدف متحدد

        public void SetGoal(double targetWeight)
        {
            if (targetWeight <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid goal weight.");
                Console.ResetColor();
                return;
            }
            WeightGoal = targetWeight;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Goal set: {WeightGoal} kg");
            Console.ResetColor();
        }

        public string CheckGoalProgress()
        {
            if (WeightGoal == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return "No goal set yet.";
            }

            double difference = Weight - WeightGoal.Value;
            if (difference == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return "Congratulations  You achieved your goal !";
            }
            else if (difference > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return $"You need to lose {difference:F1} kg to reach your goal.";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return $"Great! You are {Math.Abs(difference):F1} kg under your goal.";
            }
        }





        public bool UpdateProfile(string name, int age, double height, double weight)
        {
            if (string.IsNullOrWhiteSpace(name) || age <= 0 || height <= 0 || weight <= 0)
                return false;

            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            return true;
        }

        public string ViewProfile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"Name: {Name}\nAge: {Age}\nWeight: {Weight} kg\nHeight: {Height} cm";

        }
    }
}
