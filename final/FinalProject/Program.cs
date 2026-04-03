using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Canvas Object
        CanvasAPI canvas = new CanvasAPI();
        
        
        Console.Clear();
        Console.WriteLine("Pulling Canvas Info...");

        // Pull Student Info 
        Student student = canvas.GetStudentInfo();

        // Create Canvas Objects
        CanvasInfo info = new CanvasInfo();
        CourseMenu menu = new CourseMenu(info.GetCourses());

        // Menu Time!
        Console.Clear();
        string menuChoice = "";

        // Main Menu Loop
        while (menuChoice != "4")
        {
            // List Menu
            Console.Write($"Welcome back, ");
            student.WriteName(ConsoleColor.Green);            
            Console.WriteLine("\n\nMenu Options:\n  1. See Grades\n  2. See Assignment Info\n  3. Save Assignments (as Json)\n  4. Quit");
            
            // Get User Choice
            menuChoice = Console.ReadLine();
            
            // Switch for Menu Choice
            switch (menuChoice)
            {
                // Show Grades
                case "1":
                    Console.Clear();
                    menu.GetGrades();
                    break;

                // Get Assignment Summary
                case "2":
                    Console.Clear();

                    // Call the Assignment Menu method and store is as chosenId
                    int chosenId = menu.AssignmentMenu();

                    // Ensure an error hasn't occured
                    if (chosenId != 0)
                    {
                        // Pull Assignments
                        Console.WriteLine("Please Wait... (This might take a while depending on your internet speed)");
                        string selectedCourse = menu.GetCode(chosenId);

                        List<Assignment> assignments = info.PullAssignments(chosenId);

                        // List Assignmnets Count and await user input
                        Console.WriteLine($"Found {assignments.Count()} assignments in {selectedCourse}!");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();

                        // How many items per page
                        int perPage = 7;
                        
                        // Math trick to get the ceiling!
                        int pages = (assignments.Count() + perPage) / perPage;
                        
                        // Loop for pages
                        for (int i=0; i < (pages - 1); i++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Assignments Overview - {selectedCourse}");
                            
                            // Iterate for that specific page
                            for (int j = 0; j < perPage; j++)
                            {
                                // Get the index for the actual assignment
                                int assignmentIndex = (i * perPage) + j;

                                // Check if that index is in range then print that summary of that Assignment object
                                if (assignmentIndex < (assignments.Count() - 1))
                                {
                                    Console.WriteLine(assignments[assignmentIndex].GetSummary());
                                }
                            }

                            Console.WriteLine($"\nPress Enter (Page {i + 1} of {pages - 1})");
                            Console.ReadLine();
                        }
                        
                    }
                    
                    break;

                // Save assignments to file. Loading is future implementation
                case "3":
                    Console.Clear();
                    Console.WriteLine("Save/Load Assignments\n");

                    // Get user choice of course
                    int chosenSaveIndex = menu.AssignmentMenu();

                    // Check for error, if none continue
                    if (chosenSaveIndex != 0)
                    {
                        // Save the file with that chosen courseId
                        Console.WriteLine("Writing to file...");
                        info.SaveAssignentsToFile(chosenSaveIndex);
                        Console.WriteLine("Done! Press Enter to Continue...");
                        Console.ReadLine();
                    }
                    break;

                case "4":
                    break;
                
                default:
                    Console.Write("Invalid Choice! Try again..");
                    Thread.Sleep(1000);
                    break;
            }
            Console.Clear();
        }
        Console.WriteLine("Goodbye!");
        // canvas.PrintCoursesJson(); // TESTING 
    }
}