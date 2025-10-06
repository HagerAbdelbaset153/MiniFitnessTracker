using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MiniFitnessTracker
{
    public class Data_Manager
    {
        private string filePath = "users_data.txt";

        public void SaveUsers(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"USER|{user.Name}|{user.Age}|{user.Weight}|{user.Height}");

                    if (user.WorkoutPlans.Count == 0) continue;

                    // ترتيب الخطط حسب التاريخ
                    var orderedPlans = user.WorkoutPlans.OrderBy(p => p.Date).ToList();

                    DateTime currentDay = orderedPlans[0].Date.Date;
                    int dailyTotal = 0;

                    foreach (var plan in orderedPlans)
                    {
                        // لو يوم جديد
                        if (plan.Date.Date != currentDay)
                        {
                            // اطبع مجموع اليوم السابق
                            writer.WriteLine($"TOTAL|{dailyTotal}");

                            // ابدأ يوم جديد
                            currentDay = plan.Date.Date;
                            dailyTotal = 0;
                        }

                        writer.WriteLine($"PLAN|{plan.Date}");
                        for (int i = 0; i < plan.Exercises.Count; i++)
                        {
                            var ex = plan.Exercises[i];
                            int duration = plan.Durations[i];
                            int burned = (int)ex.CalculateCaloriesBurned(user.Weight, duration);
                            dailyTotal += burned;

                            writer.WriteLine($"EXERCISE|{ex.Name}|{ex.Type}|{user.Weight}|{duration}|{burned}");
                        }
                    }

                    // اطبع مجموع آخر يوم
                    writer.WriteLine($"TOTAL|{dailyTotal}");
                }
            }
        }




        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            if (!File.Exists(filePath))
                return users;

            User currentUser = null;
            WorkoutPlan currentPlan = null;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                switch (parts[0])
                {
                    case "USER":
                        currentUser = new User(parts[1], int.Parse(parts[2]), double.Parse(parts[3]), double.Parse(parts[4]));
                        users.Add(currentUser);
                        break;

                    case "PLAN":
                        currentPlan = new WorkoutPlan(DateTime.Parse(parts[1]));
                        currentUser.WorkoutPlans.Add(currentPlan);
                        break;

                    case "EXERCISE":
                        string name = parts[1];
                        string type = parts[2];
                        double weight = double.Parse(parts[3]);
                        int duration = int.Parse(parts[4]);
                        // parts[5] هو المحروق في التمرين (ممكن نتجاهله لأنه محسوب فعليًا)
                        Exercise ex = new Exercise(name, type);
                        currentPlan.AddExercise(ex, duration);
                        break;

                    case "TOTAL":
                        // هنا مش هنخزن أي حاجة — بس نتجاهله
                        break;
                }
            }

            return users;
        }
    }

} 





