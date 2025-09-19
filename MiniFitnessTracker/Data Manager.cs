using ConsoleApp35;
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
        private static string usersFile = "users.txt";
        private static string workoutPlansFile = "WorkoutPlans.txt";
        private static string exercisesFile = "Exercises.txt";
        private static string progressFile = "Progress.txt";

        public void DataManager()
        {
            // لو الملفات مش موجودة يعملها فاضية
            if (!File.Exists(usersFile)) File.Create(usersFile).Close();
            if (!File.Exists(exercisesFile)) File.Create(exercisesFile).Close();
            if (!File.Exists(workoutPlansFile)) File.Create(workoutPlansFile).Close();
            if (!File.Exists(progressFile)) File.Create(progressFile).Close();
        }
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

        public void SaveExercises(List<Exercise> exercises)
        {
            using (StreamWriter writer = new StreamWriter(exercisesFile))
            {
                foreach (var ex in exercises)
                {
                    writer.WriteLine($"{ex.Name},{ex.Type},{ex.CaloriesBurnedPerMin}");
                }
            }
        }

        public List<Exercise> LoadExercises()
        {
            List<Exercise> exercises = new List<Exercise>();

            if (!File.Exists(exercisesFile))
                return exercises; 

            string[] lines = File.ReadAllLines(exercisesFile);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    string type = parts[1];
                    if (double.TryParse(parts[2], out double calories))
                    {
                        Exercise ex = new Exercise
                        {
                            Name = name,
                            Type = type,
                            CaloriesBurnedPerMin = calories
                        };
                        exercises.Add(ex);
                    }
                }
            }

            return exercises;
        }
    

        public void SaveWorkoutPlan(WorkoutPlan plan)
        {
            using (StreamWriter sw = new StreamWriter(workoutPlansFile, true))
            {
                sw.WriteLine($"Date: {plan.Date.ToShortDateString()}");
                for (int i = 0; i < plan.exercises.Count; i++)
                {
                    sw.WriteLine($"Exercise: {plan.exercises[i].Name}, Type: {plan.exercises[i].Type}, Duration: {plan.durations[i]}");
                }
                sw.WriteLine("---");
            }
        }


    

        public static void SaveProgress(ProgressTracker tracker)
        {
            using (StreamWriter writer = new StreamWriter(progressFile))
            {
                writer.WriteLine($"WeeklyCalories={tracker.WeeklyCalories}");
                writer.WriteLine($"TotalWorkoutTime={tracker.TotalWorkoutTime}");
                writer.WriteLine("ExerciseStats=" + string.Join(",", tracker.ExerciseStats));
            }
        }

        public static ProgressTracker LoadProgress()
        {
            ProgressTracker tracker = new ProgressTracker();

            if (!File.Exists(progressFile))
                return tracker;

            string[] lines = File.ReadAllLines(progressFile);
            foreach (string line in lines)
            {
                if (line.StartsWith("WeeklyCalories="))
                {
                    tracker.WeeklyCalories = double.Parse(line.Split('=')[1]);
                }
                else if (line.StartsWith("TotalWorkoutTime="))
                {
                    tracker.TotalWorkoutTime = double.Parse(line.Split('=')[1]);
                }
                else if (line.StartsWith("ExerciseStats="))
                {
                    string[] stats = line.Split('=')[1].Split(',');
                    tracker.ExerciseStats = stats.ToList();
                }
            }

            return tracker;
        }
    }
}
