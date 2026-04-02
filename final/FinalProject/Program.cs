using System;

class Program
{
    static void Main(string[] args)
    {
        CanvasAPI canvas = new CanvasAPI();
        Console.Clear();
        // Console.WriteLine(student.StudentName());
        Console.WriteLine("Pulling Canvas Info...");
        Student student = canvas.GetStudentInfo();
        CanvasInfo info = new CanvasInfo();
        CourseMenu menu = new CourseMenu(info.GetCourses());

        // foreach (Course course in courses)
        // {
        //     Console.WriteLine(course.CourseString());
        // }

        string menu_choice = "";
        // Main Menu Loop
        while (menu_choice != "3")
        {
            Console.Write($"Welcome back, ");
            student.WriteName(ConsoleColor.Green);            
            Console.WriteLine("\n\nMenu Options:\n  1. See Grades\n  2. See Assignment Info\n  3. Quit");
            
            menu_choice = Console.ReadLine();
            

            switch (menu_choice)
            {
                case "1":
                    Console.Clear();
                    menu.GetGrades();
                    break;

                case "2":
                    Console.Clear();
                    int chosen_id = menu.AssignmentMenu();
                    if (chosen_id != 0)
                    {
                        Console.WriteLine("Please Wait... (This might take a while depending on your internet speed)");
                        string selected_course = menu.GetCode(chosen_id);

                        List<Assignment> assignments = info.PullAssignments(chosen_id);

                        Console.WriteLine($"Found {assignments.Count()} assignments in {selected_course}!");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();

                        // How many items per page
                        int per_page = 7;
                        
                        // Math trick to get the ceiling!
                        int pages = (assignments.Count() + per_page) / per_page;
                        
                        // Loop for pages
                        for (int i=0; i < (pages - 1); i++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Assignments Overview - {selected_course}");
                            
                            for (int j = 0; j < per_page; j++)
                            {
                                int assignment_index = (i * per_page) + j;
                                if (assignment_index < (assignments.Count() - 1))
                                {
                                    Console.WriteLine(assignments[assignment_index].GetSummary());
                                }
                            }

                            Console.WriteLine($"\nPress Enter (Page {i + 1} of {pages - 1})");
                            Console.ReadLine();
                        }
                        
                    }
                    
                    break;

                case "3":
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