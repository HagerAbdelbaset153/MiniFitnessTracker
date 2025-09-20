using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniFitnessTracker
{
    public class user
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<WorkoutPlan> workoutPlans { get; set; } = new List<WorkoutPlan>();
        public bool Updateprofile(string name, int age, double height, double weight)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            bool valid = true;
            if (string.IsNullOrWhiteSpace(name))
            {
               
                Console.WriteLine("Name cannot be empty");
              
                valid = false;
            }
            if (age < 0)
            {
                Console.WriteLine("Age must be positive");
                valid = false;

            }
            if (height <= 0)
            {
                Console.WriteLine("Height must be Positive");
                valid = false;
            }
            if (weight <= 0)
            {
                Console.WriteLine("Weight must be Positive");
                valid = false;
            }
            if (!valid)
            {
                return false;
            }
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            return true;

        }
        public string viewprofile()
        {
            return $"Name : {Name}\n Age : {Age}\n Weight : {Weight}KG\n Height : {Height}cm ";
        }
    }
}

