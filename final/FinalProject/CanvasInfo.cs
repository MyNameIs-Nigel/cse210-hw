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
        
        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;        
        // Each a is now an assignment Element
        foreach (JsonElement a in root.EnumerateArray())
        {
            Assignment assignment = new Assignment(a);
            assignments.Add(assignment);
        }

        return assignments;
    }

    public void SaveAssignentsToFile(int courseId)
    {
        string course_id = courseId.ToString();
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/courses/{course_id}/assignments?include[]=submission&per_page=100").Result;
        string json = response.Content.ReadAsStringAsync().Result;
        

        // actually write your assignments json to a file
        string path = $"assignments_{courseId}";
        File.WriteAllText(path, json);        
    }
}