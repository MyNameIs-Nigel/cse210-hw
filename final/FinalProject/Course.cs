using System.Runtime.CompilerServices;

public abstract class Course
{
    protected int _id;
    protected string _name;
    protected string _code;
    public Course(int id, string name, string code)
    {
        _id = id;
        _name = name;
        _code = code;
    }

    // Setting the grade string as a virtual, because StudentCourse needs a different one
    public virtual string GradeString()
    {
        return "No Grade Available";
    }

    // Making abstract method to call the course string
    public abstract string CourseString();

    // Getters
    public int GetCourseId()
    {
        return _id;
    }
    public string GetCourseCode()
    {
        return _code;
    }
}