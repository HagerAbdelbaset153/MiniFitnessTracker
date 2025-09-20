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
                    writer.WriteLine($"{user.Name}|{user.Age}|{user.Weight}|{user.Height}");
                }
            }
        }

        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            if (!File.Exists(filePath))
                return users;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    double weight = double.Parse(parts[2]);
                    double height = double.Parse(parts[3]);

                    users.Add(new User(name, age, weight, height));
                }
            }
            return users;
        }
    }
}





