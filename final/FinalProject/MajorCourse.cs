public class MajorCourse : Course
{
    public MajorCourse(int course_id, string course_name, string course_code) : base(course_id, course_name, course_code)
    {
        
    }

    public override string CourseString()
    {
        return $"{_code}";
    }
}