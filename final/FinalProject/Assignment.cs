using System.Text.Json;

public class Assignment
{
    // Variables that it will always have
    private string _name;
    private DateTime _due;
    private double _maxPoints;

    // Variables it might not have
    private DateTime _submissionDate;
    private double _submissionScore;

    // Booleans for logic
    private bool _submitted;
    private bool _hasDueDate;
    private bool _graded;

    // Json elements!
    private JsonElement _element;
    private JsonElement _submission;

    // Constructor that takes the "assignment" Json element.
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

    // For Future Implementation
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

    // Checks for a points_possible double in the
    // canvas API. If it exists, make that the score
    // If not, set it to 0.0
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

    // Same as SetDueDate, just for the submission sub property. 
    // For Future implementation
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

    // Set score for subproperty submission
    private void SetSubmissionScore()
    {
        // Declare the score sub property in the submission property
        JsonElement score;
        
        // Check to see first if it exists, for some reason sometimes it doesn't.
        // If it doesn't exist, set the submitted bool to false so it passed over it.
        if (_submission.TryGetProperty("score", out score))
        {
            // Then, check to see if that output is null, if it is then score defaults to 0.0
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
        else
        {
            _submitted = false;
        }

    }

    // Method to format the summary for each variable in Assignment.
    public string GetSummary()
    {
        // Check to see if this assignment is submitted by the user
        if (_submitted)
        {
            // Check if it's graded!
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
            // If no submission exists
            return $"Name: {_name}\n> Max Points: {_maxPoints} (Not Submitted)";
        }
        
    }
}