using System.Text.Json;

// Inheriting the CanvasAPI class so I can get the variables. 
public class CanvasInfo : CanvasAPI
{
    // Making a new http client, doesn't reuse or inherit CanvasAPI's client
    private HttpClient _client = new HttpClient();

    // Constructor
    public CanvasInfo()
    {
        // Vital: adding the API key to our new client's headers 
        AddHeaders(_client);
    }

    // Get courses from Canvas's API and return it as a list of Course object
    public List<Course> GetCourses()
    {
        // Declaring the courses list
        List<Course> courses = new List<Course>();

        // Making the response with the right URL and setting that to be a string as json stored in memory.
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/courses?enrollment_state=active&include[]=total_scores").Result;
        string json = response.Content.ReadAsStringAsync().Result;

        // Begin to parse the json
        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // For each enrollment element
        foreach (JsonElement element in root.EnumerateArray())
        {
            // Set the variables that are always used
            int term_id = element.GetProperty("enrollment_term_id").GetInt32();
            int course_id = element.GetProperty("id").GetInt32();
            string course_code = element.GetProperty("course_code").GetString();
            string course_name = element.GetProperty("name").GetString();


            //  Check if this is a current class or major class (is this the current term or not)
            if (term_id == _enrollmentTermId)
            {
                // For some reason canvas makes each enrollment a seperate list. So you need to select the first one
                JsonElement enrollment = element.GetProperty("enrollments")[0];

                // Setting variables for StudentCourse
                string letter_grade = enrollment.GetProperty("computed_current_grade").GetString();
                double score = enrollment.GetProperty("computed_current_score").GetDouble();

                StudentCourse course = new StudentCourse(course_id,course_name,course_code, score, letter_grade);
                courses.Add(course);
            }
            else
            {
                // Making the MajorCourse
                MajorCourse course = new MajorCourse(course_id, course_name, course_code);
                courses.Add(course);
            }
        }
        // Return the list
        return courses;
    }

    // This one sucked to write. Pulls the assignments for that given courseId
    public List<Assignment> PullAssignments(int courseId)
    {
        // Declare List
        List<Assignment> assignments = new List<Assignment>();
        
        // For some reason, courseId needs to be a string, but it's an int everywhere else sooooo
        string course_id = courseId.ToString();
        
        // Create the response asking Canvas for 100 assignments (max) at a time. This makes the request take a while, but it's easier than doing pages
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/courses/{course_id}/assignments?include[]=submission&per_page=100").Result;
        string json = response.Content.ReadAsStringAsync().Result;
        
        // Parsing that Json
        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // Each a is now an assignment Element
        foreach (JsonElement a in root.EnumerateArray())
        {
            // Most the logic is handled by the Assignment class! Woohoo!
            Assignment assignment = new Assignment(a);
            assignments.Add(assignment);
        }

        return assignments;
    }

    // Save the raw json to a file. For future implementation.
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