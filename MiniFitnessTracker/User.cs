using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm
        public List<WorkoutPlan> WorkoutPlans { get; set; }

        public User(string name, int age, double weight, double height)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            WorkoutPlans = new List<WorkoutPlan>();
        }
        
    }
}
