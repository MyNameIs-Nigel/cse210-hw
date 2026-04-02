using System.Text.Json;

public class Assignment
{
    private string _name;
    private DateTime _due;
    private bool _hasDueDate;
    private double _maxPoints;
    private DateTime _submissionDate;
    private double _submissionScore;
    private bool _submitted;
    private bool _graded;
    private JsonElement _element;
    private JsonElement _submission;

    public Assignment(JsonElement assignment)
    {
        _element = assignment;
        _name = assignment.GetProperty("name").GetString();
        // Debug
        // Console.WriteLine($"Made Assignment! {assignment.GetProperty("name").GetString()}");


        // Work Through Each Variable, Individually
        SetDueDate();
        SetMaxPoints();

        // Ensuring the submission property exists before settings the submission variables. 
        if (assignment.TryGetProperty("submission", out _submission))
        {
            SetSubmissionDate();
            SetSubmissionScore();
        }
        else
        {
            // Debug
            // Console.WriteLine("No Submission Yet!");
        }
    }

    private void SetDueDate()
    {
        string date = _element.GetProperty("due_at").GetString();
        
        if (DateTime.TryParse(date, out _due))
        {
            _hasDueDate = true;
            
            // Debug:
            // Console.Write("True!");
        }
        else
        {
            _hasDueDate = false;

            // Debug:
            // Console.Write("False!");
        }
    }

    private void SetMaxPoints()
    {
        double points;

        if (_element.GetProperty("points_possible").TryGetDouble(out points))
        {
            _maxPoints = points;
        }
        else
        {
            _maxPoints = 0.0;

            // debug:
            // Console.WriteLine("Found 0 point assignment!");
        }
    }

    private void SetSubmissionDate()
    {
        string date = _submission.GetProperty("submitted_at").GetString();

        if (DateTime.TryParse(date, out _submissionDate))
        {
            _submitted = true;
            
            // debug
            // Console.WriteLine("FOUND A DATE!");
        }
        else
        {
            _submitted = false;
        }
    }

    private void SetSubmissionScore()
    {
        JsonElement score = _submission.GetProperty("score");

        if (score.ValueKind == JsonValueKind.Null)
        {
            _graded = false;
            _submissionScore = 0.0;
        }
        else
        {
            _graded = true;
            _submissionScore = score.GetDouble();
        }
    }

    public string GetSummary()
    {
        // Check to see if this assignment is submitted by the user
        if (_submitted)
        {
            if (_graded)
            {
                return $"Name: {_name}\n> Grade: [{_submissionScore} / {_maxPoints}]";
            }
            else
            {
                return $"Name: {_name}\n> Max Points: {_maxPoints} (Not Graded)";
            }
        }
        else
        {
            return $"Name: {_name}\n> Max Points: {_maxPoints} (Not Submitted)";
        }
        
    }
}