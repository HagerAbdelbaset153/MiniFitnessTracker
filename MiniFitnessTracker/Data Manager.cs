using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{
    class Data_Manager
    {
        private string usersFile = "users.txt";
        private string workoutPlansFile = "WorkoutPlans.txt";
        private string exercisesFile = "Exercises.txt";
        private string progressFile = "Progress.txt";

        public void SaveUser(User user)
        {
            using (StreamWriter sw = new StreamWriter(usersFile, true))
            {
                sw.WriteLine($"Name: {user.Name}");
                sw.WriteLine($"Age: {user.Age}");
                sw.WriteLine($"Weight: {user.Weight}");
                sw.WriteLine($"Height: {user.Height}");
                sw.WriteLine("----------------------");
            }
        }
        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            if (!File.Exists(usersFile))
                return users;

            string[] lines = File.ReadAllLines(usersFile);
            string name = "";
            int age = 0;
            double weight = 0, height = 0;

            foreach (string line in lines)
            {
                if (line.StartsWith("Name:"))
                    name = line.Substring(5).Trim();
                else if (line.StartsWith("Age:"))
                    age = int.Parse(line.Substring(4).Trim());
                else if (line.StartsWith("Weight:"))
                    weight = double.Parse(line.Substring(7).Trim());
                else if (line.StartsWith("Height:"))
                    height = double.Parse(line.Substring(7).Trim());
                else if (line == "---")
                {
                    users.Add(new User(name, age, weight, height));
                    name = ""; age = 0; weight = 0; height = 0;
                }
            }

            return users;
        }
        public void SaveExercise(Exercise exercise)
        {
            using (StreamWriter sw = new StreamWriter(exercisesFile, true))
            {
                sw.WriteLine($"Name: {exercise.Name}");
                sw.WriteLine($"Type: {exercise.Type}");
                sw.WriteLine("---");
            }
        }
        public static List<Exercise> LoadExercises(string exercisesFile)
        {
            List<Exercise> exercises = new List<Exercise>();

            if (!File.Exists(exercisesFile))
                return exercises;

            string[] lines = File.ReadAllLines(exercisesFile);
            string name = "";
            ExerciseType type = ExerciseType.Cardio;

            foreach (string line in lines)
            {
                if (line.StartsWith("Name:"))
                {
                    name = line.Substring(5).Trim();
                }
                else if (line.StartsWith("Type:"))
                {
                    string typeStr = line.Substring(5).Trim();
                    if (Enum.TryParse(typeStr, out ExerciseType parsedType))
                    {
                        type = parsedType;
                    }
                    else
                    {
                        type = ExerciseType.Cardio;
                    }
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        exercises.Add(new Exercise(name, type));
                        name = "";
                        type = ExerciseType.Cardio;
                    }
                }
            }

            if (!string.IsNullOrEmpty(name))
            {
                exercises.Add(new Exercise(name, type));
            }

            return exercises;
        }
    }
}
