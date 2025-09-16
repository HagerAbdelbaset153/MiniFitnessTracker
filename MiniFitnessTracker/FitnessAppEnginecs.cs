using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{
    class FitnessAppEnginecs
    {
        public List<User> Users { get; set; }       
        public User CurrentUser { get; set; }

        public FitnessAppEnginecs()
        {
            Users = new List<User>();
            CurrentUser = null;
        }
        public void ShowMenu()
        {
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. Update Profile");
            Console.WriteLine("3. Log Workout");
            Console.WriteLine("4. Show Progress");
            Console.WriteLine("5. Exit");
        }
        public void LogWorkout()
        {
            WorkoutPlan plan = new WorkoutPlan(DateTime.Now);
            bool addMore = true;

            while (addMore)
            {
                Console.Write("Enter exercise name: ");
                string nameExercise = Console.ReadLine();
                bool invalid = true;
                while (invalid)
                {
                    if (string.IsNullOrWhiteSpace(nameExercise))
                    {
                        Console.Write("\nExercise name cannot be empty. Please enter again: ");
                        nameExercise = Console.ReadLine();
                    }
                    if (nameExercise.Any(char.IsDigit))
                    {
                        Console.Write("\nExercise name cannot be a number. Please enter again: ");
                        nameExercise = Console.ReadLine();
                    }
                    else
                    {
                        invalid = false;
                    }

                }

                Console.WriteLine("\nSelect exercise type:");
                Console.WriteLine("1. Cardio");
                Console.WriteLine("2. Strength");
                Console.WriteLine("3. Yoga");
                Console.Write("Enter your choose: ");
                string typeChoice = Console.ReadLine();
                ExerciseType exerciseType = new ExerciseType();
                bool valid = false;
                while (!valid)
                {
                    if (string.IsNullOrWhiteSpace(typeChoice))
                    {
                        Console.Write("\nChoice cannot be empty.Please enter again: ");
                        typeChoice = Console.ReadLine();
                    }
                    else
                    {
                        switch (typeChoice)
                        {
                            case "1":
                                exerciseType = ExerciseType.Cardio;
                                valid = true;
                                break;
                            case "2":
                                exerciseType = ExerciseType.Strength;
                                valid = true;
                                break;
                            case "3":
                                exerciseType = ExerciseType.Yoga;
                                valid = true;
                                break;
                            default:
                                Console.Write("\nInvalid choose. Please enter again: ");
                                typeChoice = Console.ReadLine();
                                break;
                        }
                    }
                }

                Console.Write("\nEnter duration exercise in minutes: ");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.Write("\nInvalid duration. Please enter again: ");
                }

                Exercise exercise = new Exercise(nameExercise, exerciseType);

                plan.AddExercise(exercise, duration);

                Console.Write("\nAdd another exercise? (y/n): ");
                string ans = Console.ReadLine();
                while (true)
                {
                    if(string.IsNullOrWhiteSpace(ans))
                    { 
                        Console.Write("\nAnswer cannot be empty. Please enter again: ");
                        ans = Console.ReadLine();
                    }
                    else if (ans.ToLower() == "y")
                    {
                        Console.WriteLine("\n===Exercise details===");
                        break;
                    }
                    else if (ans.ToLower() == "n")
                    {
                        addMore = false;
                        break;
                    }
                    else
                    {
                        Console.Write("\nInvalid answer. Please enter again: ");
                        ans = Console.ReadLine();
                    }

                }
                
            }

            CurrentUser.WorkoutPlans.Add(plan);

            /*double totalCalories = plan.CalculateDailyCalories(CurrentUser.Weight);
            Console.WriteLine($"Total calories burned today: {totalCalories}");*/

        }

        
        
    }
}
