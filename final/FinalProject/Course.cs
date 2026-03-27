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

    public virtual string GradeString()
    {
        return "No Grade Available";
    }
    public abstract string CourseString();
}