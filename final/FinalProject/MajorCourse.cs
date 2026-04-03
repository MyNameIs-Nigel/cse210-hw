public class MajorCourse : Course
{
    // Constructor
    public MajorCourse(int courseId, string course_name, string courseCode) : base(courseId, course_name, courseCode){}

    // Overriden CourseString 
    public override string CourseString()
    {
        return $"[MAJOR] {_code}";
    }

    public override string GradeString()
    {
        return "No Grade Available";
    }
}