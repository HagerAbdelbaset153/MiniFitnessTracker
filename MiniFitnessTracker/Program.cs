using System;
using System.Collections.Generic;
using System.Linq;



namespace MiniFitnessTracker
{


    class ExceptionHandling : Exception
    {
        public static int ValidInt(string prompt, int? min = null, int? max = null)
        {
            int value;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(prompt);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                var s = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(s, out value))
                {
                    if ((min == null || value >= min) && (max == null || value <= max))
                        return value;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please enter number between {min} and {max}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!!..Please enter a number.");
                    Console.ResetColor();
                }
            }
        }

        public static string NonEmptyString(string prompt)
        {
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(prompt);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                input = Console.ReadLine()?.Trim();
                Console.ResetColor();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }


      
    }
    public class Program
    {


        public static void PrintCentered(string text, ConsoleColor color = ConsoleColor.White)
        {
            int windowWidth = Console.WindowWidth;
            int leftPadding = (windowWidth - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;

            Console.ForegroundColor = color;
            Console.WriteLine(new string(' ', leftPadding) + text);
            Console.ResetColor();
        }
        public static void ThanksHelper()
        {
            PrintCentered("===========================================", ConsoleColor.Magenta);
            PrintCentered("🌟🌟🌟   THANK YOU TEAM HELPERS   🌟🌟🌟", ConsoleColor.Cyan);
            PrintCentered("💖 Your support means the world to us 💖", ConsoleColor.Green);
            PrintCentered("🚀 Together, we keep moving forward stronger! 💪", ConsoleColor.Yellow);
            PrintCentered("===========================================", ConsoleColor.Magenta);
        }



        static FitnessAppEngine engine = new FitnessAppEngine();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
             
           

            Console.ForegroundColor = ConsoleColor.Yellow;


            PrintCentered("===========================================", ConsoleColor.Green);
            PrintCentered("🌟🌟🌟   WELCOME TO MINI FITNESS TRACKER   🌟🌟🌟", ConsoleColor.Yellow);
            PrintCentered("💪 Stay fit, stay motivated! 💪", ConsoleColor.Yellow);
            PrintCentered("===========================================", ConsoleColor.Green);


            bool exit = false;
            while (!exit)
            {
              Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("\n==== Main Menu ====");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");Console.ResetColor();
                int choice = ExceptionHandling.ValidInt("Choose option: ", 1, 3);
                switch (choice)
                {
                    case 1:
                        engine.Register();
                        break;
                    case 2:
                        engine.Login();
                        if (engine.CurrentUser != null) SubMenu();
                        break;
                    case 3:
                        engine.SaveData();
                        exit = true;
                        break;
                }
            }
        }

        static void SubMenu()
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("====== Mini Fitness Tracker ======");
                Console.WriteLine("1. Log Workout");
                Console.WriteLine("2. View Progress");
                Console.WriteLine("3.CalculateBMI");
                Console.WriteLine("4.SetGoal");
                Console.WriteLine("5. Logout");
                Console.WriteLine("6. Thanks Helper");
                Console.WriteLine("7. Exit");
                Console.ResetColor();
                int choice = ExceptionHandling.ValidInt("Choose an option: ", 1, 7);

                switch (choice)
                {
                    case 1:
                        engine.LogWorkoutMenu();
                        engine.SaveData();
                        break;
                    case 2:
                        engine.ViewProgress();
                        break;
                    case 3:
                        Console.WriteLine(engine.CurrentUser.CalculateBMI());
                        Console.WriteLine("Press Enter to return to menu...");
                        Console.ReadLine();
                        break;
                    case 4:
                        double targetWeight = ExceptionHandling.ValidInt("Enter your target weight (kg): ", 1);
                        engine.CurrentUser.SetGoal(targetWeight);
                        Console.WriteLine(engine.CurrentUser.CheckGoalProgress());
                        Console.WriteLine("Press Enter to return to menu...");
                        Console.ReadLine();
                        engine.SaveData();
                        break;
                    case 5:
                        engine.Logout();
                        return; // يرجع للـ Main Menu
                    case 6:
                        PrintCentered("===========================================", ConsoleColor.Magenta);
                        PrintCentered("🌟🌟🌟   THANK YOU TEAM HELPERS   🌟🌟🌟", ConsoleColor.Yellow);
                        PrintCentered("🙏💖 Thank you for all your effort and time! 💖", ConsoleColor.Yellow);
                        PrintCentered("🚀We hope the Helpers family keeps going helping more people , like it helped us ! 💖", ConsoleColor.Yellow);
                        PrintCentered("===========================================", ConsoleColor.Magenta);
                        Console.WriteLine("\nPress Enter to return to menu...");
                        Console.ReadLine(); 
                        //ThanksHelper();
                        break;

                    case 7:
                        engine.SaveData();
                        exitApp = true;
                        break;
                }
            }
        }
    }
}






