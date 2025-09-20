using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MiniFitnessTracker
{
    public class FitnessAppEngine
    {
        public List<User> Users { get; set; }
        public User CurrentUser { get; set; }
        private Data_Manager dataManager;

        public FitnessAppEngine()
        {
            dataManager = new Data_Manager();
            Users = dataManager.LoadUsers();
            CurrentUser = null;
        }

        public void SaveData()
        {
            dataManager.SaveUsers(Users);
        }

        public void Register()
        {
            string name = ExceptionHandling.NonEmptyString("Enter name: ");
            int age = ExceptionHandling.ValidInt("Enter age: ", 1, 100);
            double weight = ExceptionHandling.ValidInt("Enter weight: ", 20, 300);
            double height = ExceptionHandling.ValidInt("Enter height (cm): ", 50, 250);

            User user = new User(name, age, weight, height);
            Users.Add(user);
            SaveData();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Registration successful!");
            Console.ResetColor();
        }



        public void Login()
        {
            if (Users.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No users registered yet.");
                Console.ResetColor();
                return;
                
            }

            string name = ExceptionHandling.NonEmptyString("Enter name: ");
            CurrentUser = Users.FirstOrDefault(u => u.Name == name);

            if (CurrentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome, {CurrentUser.Name}!");
            Console.ResetColor();
        }


        public void ViewProgress()
        {
            if (CurrentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please login first.");
                Console.ResetColor();
                return;
            }

            if (CurrentUser.WorkoutPlans.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" No workouts logged yet for {CurrentUser.Name}.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n=== Workout Progress for {CurrentUser.Name} ===");
            Console.ResetColor();

            int totalCalories = 0;
            foreach (var plan in CurrentUser.WorkoutPlans)
            {
                Console.WriteLine($"\n {plan.Date.ToShortDateString()}");
                foreach (var exercise in plan.Exercises)
                {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"   - {exercise.Name} ({exercise.Type}), {exercise.CaloriesBurnedPerMin} cal/min");
                    totalCalories += (int)exercise.CaloriesBurnedPerMin;

                }
                    Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n Total Calories Burned: {totalCalories}");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nPress Enter to return to menu...");
            Console.ResetColor();
            Console.ReadLine();
        }





        public void Logout()
        {
            if (CurrentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No user is logged in.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Goodbye, {CurrentUser.Name}!");
            CurrentUser = null;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void LogWorkoutMenu()
        {
            if (CurrentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please login first.");
                Console.ResetColor();
                return;
            }

            bool backToMenu = false;

            while (!backToMenu)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=== Log Workout Menu ===");
                Console.WriteLine("Choose a workout category:");
               
                int index = 1;
                foreach (var category in Enum.GetValues(typeof(WorkoutCategory)))
                {
                    Console.WriteLine($"{index}. {category}");
                    index++;
                }
                
                Console.WriteLine($"{index}. Back to Main Menu");
                
                int choice = ExceptionHandling.ValidInt("Enter choice: ", 1, index);

                if (choice == index)
                {
                    backToMenu = true;
                    break;
                }

                WorkoutCategory selectedCategory = (WorkoutCategory)(choice - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou chose {selectedCategory}. Available exercises:");

                List<string> exercises = WorkoutRepository.Workouts[selectedCategory];
                for (int i = 0; i < exercises.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {exercises[i]}");
                }
                Console.WriteLine($"{exercises.Count + 1}. Back to Workout Categories");

                int exChoice = ExceptionHandling.ValidInt("Choose exercise: ", 1, exercises.Count + 1);

                if (exChoice == exercises.Count + 1)
                {
                    continue;
                }

                string chosenExercise = exercises[exChoice - 1];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n You logged: {chosenExercise} ({selectedCategory})");
                Console.ForegroundColor = ConsoleColor.Green;

                int duration = ExceptionHandling.ValidInt("Enter duration in minutes: ", 1, 500);

                Exercise ex = new Exercise(chosenExercise, selectedCategory.ToString(), 5);

                WorkoutPlan plan = new WorkoutPlan(DateTime.Now);
                plan.AddExercise(ex, duration);

                CurrentUser.WorkoutPlans.Add(plan);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Workout saved!\n");
                backToMenu = true;
                Console.ResetColor();
            }
        }
    }
}



