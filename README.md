# 🏋️‍♀️ Mini Fitness Tracker

A console-based project built with C# to track fitness exercises and calculate calories burned. This application allows users to add exercises with a name, type, and calories burned per minute, view the existing exercises, and compute total calories burned given a duration. The structure follows Object-Oriented Programming (OOP) principles.

## 📂 Project Files
- MiniFitnessTracker.sln — solution file.  
- .gitignore — list of files/folders excluded from version control.  
- .gitattributes — Git attributes settings.  

## 📦 Project Classes
- Class1.cs (User Class) — calculate BMI, set goal, check goal progress.  
- DataManager.cs — handles saving, loading, and managing exercise data.  
- Exercise.cs — defines the base exercise with name, type, and calories burned per minute.  
- FitnessAppEngines.cs — contains the core logic and engines that run the fitness app.  
- Program.cs — entry point of the application where execution starts.  
- ProgressTracker.cs — tracks user progress such as calories burned over time.  
- WorkoutPlan.cs — manages workout plans and organizes different exercises into routines.  

## 🚀 How to Run
1. Clone the repository or download it.  
2. Open the solution MiniFitnessTracker.sln in Visual Studio or another compatible IDE.  
3. Ensure the .NET SDK is installed.  
4. Run the application from Visual Studio, or via command line:  
`bash
dotnet run --project MiniFitnessTracker

✨ Future Enhancements :

- Persist data (e.g. save exercises) in a file or a database.

- Add a user interface (GUI) to improve user interaction.

- Support tracking of total daily calories burned.

- Add validation (e.g. avoid negative duration or calories).


👩‍💻 Contributors : 

- Hager Abdelbaset
- Aml Osman
- Malak Mamdouh
- Malak Abdelrahim
- Sohila Metwally
