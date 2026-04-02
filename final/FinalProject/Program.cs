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
                    info.PullAssignments(chosen_id);
                    
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