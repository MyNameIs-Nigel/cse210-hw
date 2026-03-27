public class StudentCourse : Course {
    private Grade _grade;
    private List<Assignment> _assignments;
    public StudentCourse(int id, string name, string code, double score, string letter_grade) : base(id,name,code)
    {
        _assignments = new List<Assignment>();
        _grade = new Grade(score, letter_grade);
    }

    public List<Assignment> GetAssignments()
    {
        return _assignments;
    }

    public override string CourseString()
    {
        return $"({_code}) {_name}";
    }

    public override string GradeString()
    {
        string letter_grade = _grade.GetLetter();
        double score = _grade.GetScore();

        return $"{score} ({letter_grade})"; 
    }
}