using System.Text.Json;

public class CanvasInfo : CanvasAPI
{
    private HttpClient _client = new HttpClient();
    public CanvasInfo()
    {
        AddHeaders(_client);
    }

    public List<Assignment> PullAssignments()
    {
        List<Assignment> assignments = new List<Assignment>();
        return assignments;
    }

    public List<Course> GetCourses()
    {
        List<Course> courses = new List<Course>();

        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/courses?enrollment_state=active&include[]=total_scores").Result;

        string json = response.Content.ReadAsStringAsync().Result;

        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        foreach (JsonElement element in root.EnumerateArray())
        {
            int term_id = element.GetProperty("enrollment_term_id").GetInt32();
            int course_id = element.GetProperty("id").GetInt32();

            string course_code = element.GetProperty("course_code").GetString();
            string course_name = element.GetProperty("name").GetString();


            //  Check if this is a current class or major class (is this the current term or not)
            if (term_id == _enrollmentTermId)
            {
                JsonElement enrollment = element.GetProperty("enrollments")[0];

                
                string letter_grade = enrollment.GetProperty("computed_current_grade").GetString();
                double score = enrollment.GetProperty("computed_current_score").GetDouble();
                // string letter_grade = "A-";
                // double score = 92.53;

                StudentCourse course = new StudentCourse(course_id,course_name,course_code, score, letter_grade);
                courses.Add(course);
            }
            else
            {
                MajorCourse course = new MajorCourse(course_id, course_name, course_code);
                courses.Add(course);
            }
        }

        return courses;
    }

public List<Assignment> PullAssignments(int courseId)
    {
        List<Assignment> assignments = new List<Assignment>();
        string course_id = courseId.ToString();
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/courses/{course_id}/assignments?include[]=submission&per_page=100").Result;
        string json = response.Content.ReadAsStringAsync().Result;
        

        // Code to write your assignments json to a file (for testing)
        // string path = $"assignments_{courseId}";
        // File.WriteAllText(path, json);

        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;        
        // Each a is now an assignment Element
        foreach (JsonElement a in root.EnumerateArray())
        {
            DateTime due_date;
            string due_string = a.GetProperty("due_at").GetString();
            if (DateTime.TryParse(due_string, out due_date))
            {
                // Debug:
                Console.WriteLine("Found due date {}");
            }
            else
            {
                // Change Me.
                due_date = DateTime.Now;
            }

            string submission_type = a.GetProperty("submission_types")[0].ToString();
            int assignment_id = a.GetProperty("id").GetInt32();
            string assignment_name = a.GetProperty("name").GetString();
            double max_points = a.GetProperty("points_possible").GetDouble();
            bool submitted;
            if (submission_type == "none")
            {
                // Debug Messages:
                Console.WriteLine($"Found Checkbox Assignment! #{assignment_id}");
            }
            else
            {
                // Debug Messages:
                Console.WriteLine($"Found Normal Assignment! #{assignment_id}");

                JsonElement submission;
                if (a.TryGetProperty(("submission"), out submission))
                {
                    bool submission_late = submission.GetProperty("late").GetBoolean();
                    double submission_score;
                    // Attempting to make the submission score value.
                    if (submission.GetProperty("score").TryGetDouble(out submission_score))
                    {
                        Console.WriteLine("Submission Score Exists.");
                    }
                    else
                    {
                        submission_score = 0.0;
                    }
                }
                else
                {
                    submitted = false;
                }
            }
        }

        // OLD CODE, doesn't work well. 

        // foreach (JsonElement assignment in root.EnumerateArray())
        // {
        //     Assignment a1;
        //     string submission_type = assignment.GetProperty("submission_types").ToString();
        //     string a1_name = assignment.GetProperty("name").GetString();
        //     double a1_max_points = assignment.GetProperty("points_possible").GetDouble();
        //     DateTime a1_due_date = DateTime.Now;
        //     // DateTime a1_due_date = assignment.GetProperty("due_at").GetDateTime();
        //     bool a1_submitted = assignment.GetProperty("has_submitted_submissions").GetBoolean();
            
        //     if (submission_type == "none")
        //     {
        //         // Console Logs
        //         Console.WriteLine("Found Checkbox Assignment!");
        //         Console.WriteLine(a1_name);

        //         a1 = new CheckboxAssignment(a1_name, a1_due_date, a1_max_points, a1_submitted);
        //     }
        //     else
        //     {
        //         // Checks if there IS a submission, if not score is auto zero
        //         JsonElement submission;
        //         if (assignment.TryGetProperty("submission", out submission))
        //         {
        //             bool a1_graded;
        //             Console.WriteLine("Found Submitted Normal Assignment");
        //             double a1_score = 0.0;
        //             a1_graded = false;
        //             if (submission.GetProperty("score").ValueKind != JsonValueKind.Null)
        //             {
        //                 a1_score = submission.GetProperty("score").GetDouble();
        //                 a1_graded = true;
        //             }
        //             // DateTime a1_submission_time = submission.GetProperty("submitted_at").GetDateTime();
        //             DateTime a1_submission_time = DateTime.Now;
        //             bool a1_late = submission.GetProperty("late").GetBoolean();
        //             a1 = new NormalAssignment(a1_name, a1_due_date, a1_max_points, a1_score, a1_submission_time, a1_late, a1_graded);
        //         }
        //         else
        //         {
        //             Console.WriteLine("Found Unsubmitted Normal Assignment");
        //             a1 = new NormalAssignment(a1_name, a1_due_date, a1_max_points, 0, DateTime.Now, false, false);

        //         }
        //     }
        //     // Add the assignment a1 to the list!
        //     assignments.Add(a1);
        // }
        Console.ReadLine();
        return assignments;
    }
}