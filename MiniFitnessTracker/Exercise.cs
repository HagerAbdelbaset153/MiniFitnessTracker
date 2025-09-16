using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{
    public enum ExerciseType
    {
        Cardio,
        Strength,
        Yoga
    }

    public class Exercise
    {
        public string Name { get; set; }
        public ExerciseType Type { get; set; }
        public double MET { get; private set; }

        public Exercise(string name, ExerciseType type)
        {
            Name = name;
            Type = type;
            MET = GetMETValue(type);
        }

        private double GetMETValue(ExerciseType type)
        {
            switch (type)
            {
                case ExerciseType.Cardio: return 7.0;
                case ExerciseType.Strength: return 6.0;
                case ExerciseType.Yoga: return 2.5;
                default: return 4.0;
            }
        }

        public double CalculateCalories(int durationMinutes, double userWeight)
        {
            double hours = durationMinutes / 60.0;
            return MET * userWeight * hours;
        }
    }

}
