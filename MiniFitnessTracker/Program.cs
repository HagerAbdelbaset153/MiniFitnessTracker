using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFitnessTracker
{
    class EceptionHandling : Exception
    {
        public static int ValidInt(string prompt, int? min = null, int? max = null)  //داله بتتاكد ان المستخدم ادخل رقم
        {
            int value;

            while (true)
            {

                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (min == null || max == null)
                    {
                        return value;
                    }
                    else
                    {

                        if (value >= min && value <= max)
                        {
                            return value;
                        }
                        else
                        {
                            Console.WriteLine($"Plese enter Numper Between{min}:{max}");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!!..Please enter a number.");
                }
            }

        }

        public static string NonEmptyString(string prompt)  //داله بتتاكد ان  النص مش null
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

            } while (string.IsNullOrEmpty(input));

            return input;

        }

        public static string IsNumper_NonEmptyString(string prompt)
        {

            string input;
            bool isValid;
            do
            {

                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                isValid = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
                if (!isValid)
                {
                    Console.WriteLine("Please enter numbers only and do not leave the field blank...");
                }
            } while (!isValid);



            return input;

        }

    }












    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mini Fitness Tracker! aml");
        }
    }
}
