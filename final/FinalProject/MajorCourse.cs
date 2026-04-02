public class MajorCourse : Course
{
    // Constructor
    public MajorCourse(int course_id, string course_name, string course_code) : base(course_id, course_name, course_code)
    {
        
    }

    // Overriden CourseString 
    public override string CourseString()
    {
        return $"[MAJOR] {_code}";
    }
}