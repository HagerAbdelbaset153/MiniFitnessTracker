using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{

        public class Program
        {
            public void ShowMenu()
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n    ==== Mini Fitness Tracker ====");
                Console.WriteLine("      1. Log Workout      ");
                Console.WriteLine("      2. View Progress      ");
                Console.WriteLine("      3. Manage Profile     ");
                Console.WriteLine("      4. Exit              ");
                Console.WriteLine("  ==============================");
                Console.ResetColor();

            }
            public void LogWorkout()
            {
                Console.WriteLine("=== Log Workout ===");
                Console.Write("Enter exercise name: ");
                string exercise = Console.ReadLine();

                Console.Write("Enter duration (minutes): ");
                string durationInput = Console.ReadLine();
                int duration = int.TryParse(durationInput, out int d) ? d : 0;

                Console.WriteLine($" Workout logged: {exercise} for {duration} minutes.");
            }

            public void ViewProgress()
            {
                Console.WriteLine("=== View Progress ===");
                Console.WriteLine("Showing dummy progress for now...");
            }

            public void ManageProfile()
            {
                Console.WriteLine("=== Manage Profile ===");
                Console.WriteLine("Showing dummy profile for now...");

            }

            static void Main(string[] args)
            {


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome To Mini Fitness Tracker ");
                Console.ResetColor();
                Program program = new Program();

                while (true)
                {
                    program.ShowMenu();
                    Console.Write("Enter your choice :  ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input) || !input.All(char.IsDigit))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter number");
                        Console.ResetColor();

                    }
                    else
                    {
                        int choice = int.Parse(input);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine(" 1. Log Workout ");
                                program.LogWorkout();

                                break;
                            case 2:
                                Console.WriteLine("2. View Progress ");

                                program.ViewProgress();
                                break;
                            case 3:
                                Console.WriteLine(" 3. Manage Profile  ");

                                program.ManageProfile();


                                break;
                            case 4:
                                Console.WriteLine(" 4. Exit    ");

                                return;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice, please try again.");
                                Console.ResetColor();
                                break;

                        }

                    }
                }
            }
        }
    }
