using System.Xml.Serialization;
using System.Text.Json;

public class CourseMenu : CanvasAPI
{
    // Setting the Variables
    private List<Course> _courses;

    // Constructors
    public CourseMenu(List<Course> coursesList)
    {
        _courses = coursesList;
    }

    // Menu for Grades that uses the list of Courses
    public void GetGrades()
    {

        Console.WriteLine("Grades: (Skips Major Courses)\n");
        // Iterate through the courses. Was a foreach but I wanted to list index number. But it skips major courses sooo its gonna be off
        for (int i=0; i<_courses.Count(); i++)
        {
            // Setting Variables
            string scoreString = _courses[i].GradeString();

            // Check if it's a major course
            if (scoreString != "No Grade Available")
            {
                Console.WriteLine($"{_courses[i].CourseString()}\n- {scoreString}");
            }
        }        
        Console.Write("\nPress Enter to Continue... ");
        Console.ReadLine();
    }

    // Get the course Code string for that given courseId 
    public string GetCode(int courseId)
    {
        string code = "Error!";
        foreach (Course course in _courses)
        {
            if (course.GetCourseId() == courseId)
            {
                code = course.GetCourseCode();
            }
        }

        return code;
    }
    // Choose a course code (IF ERROR SET IT TO 0)
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