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
        List<Course> courses = canvas.GetCourses();

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
                Console.WriteLine("Grades: ");
                for (int i=0; i<courses.Count(); i++)
                    {
                        string score_string = courses[i].GradeString();
                        Console.WriteLine($"{i + 1}. {courses[i].CourseString()}\n>  {score_string}");
                    }
                Console.Write("\nPress Enter to Continue... ");
                Console.ReadLine();
                break;

                case "2":
                Console.Clear();
                int course_id = canvas.CourseMenu();

                Console.Write("\nPress Enter to Continue... ");
                break;

                case "3":
                break;
                
                default:
                break;
            }
            Console.Clear();
        }
        Console.WriteLine("Goodbye!");
        // canvas.PrintCoursesJson(); // TESTING 
    }
}