using System.Xml.Serialization;
using System.Text.Json;

public class CourseMenu : CanvasAPI
{

    private List<Course> _courses;

    public CourseMenu(List<Course> coursesList)
    {
        _courses = coursesList;
    }

    public void GetGrades()
    {
        Console.WriteLine("Grades: (Skips Major Courses)");

        for (int i=0; i<_courses.Count(); i++)
        {

            string score_string = _courses[i].GradeString();

            if (score_string != "No Grade Available")
            {
                Console.WriteLine($"{i + 1}. {_courses[i].CourseString()}\n>  {score_string}");
            }
        }        
        Console.Write("\nPress Enter to Continue... ");
        Console.ReadLine();
    }

    public int AssignmentMenu()
    {
        Console.WriteLine("Courses:  ");

        for (int i=0; i<_courses.Count(); i++)
        {
            Console.WriteLine($"{i+1}: {_courses[i].CourseString()}");
        }

        Console.Write("\nEnter a Selection to Continue... ");
        string attempt = Console.ReadLine();

        int choice;
        if (int.TryParse(attempt, out choice))
        {
            if (choice <= _courses.Count() && choice >= 1)
            {
                int courseId = _courses[choice - 1].GetCourseId();
                return courseId;
            }
            else
            {
                Console.WriteLine("Uh oh! That's not a valid course in the list... Press Enter to Continue");
                Console.ReadLine();
                return 0;
            }
        }
        else
        {
            Console.WriteLine("Uh oh! That's not a valid number... Press Enter to Continue");
            Console.ReadLine();
            return 0;
        }
    }
}