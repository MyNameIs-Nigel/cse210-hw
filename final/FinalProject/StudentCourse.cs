public class StudentCourse : Course {
    // Declaring Variables
    private Grade _grade;
    private List<Assignment> _assignments;

    // Constructor
    public StudentCourse(int id, string name, string code, double score, string letter_grade) : base(id,name,code)
    {
        // New assignments list (NOT USED CURRENTLY)
        _assignments = new List<Assignment>();

        // new Grade object
        _grade = new Grade(score, letter_grade);
    }

    // Getters
    public List<Assignment> GetAssignments()
    {
        return _assignments;
    }

    // Overridden CourseString for actual student courses
    public override string CourseString()
    {
        return $"[{_code}] {_name}";
    }

    // Overridden Grade string with grade info!
    public override string GradeString()
    {
        string letter_grade = _grade.GetLetter();
        double score = _grade.GetScore();

        return $"{letter_grade} - {score}"; 
    }
}