using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

public class CanvasAPI
{
    private HttpClient _client = new HttpClient();
    

    private string _canvasUrl;
    private int _enrollmentTermId = 419;
    private string _apikey;
    public CanvasAPI()
    {
        _apikey = APIKeyFromFile();
        _canvasUrl = "https://byui.instructure.com/api/v1";
        AddHeaders();
    }

    private string APIKeyFromFile(string filename = ".env")
    {
        string[] lines = File.ReadAllLines(filename);

        string key = "NO_API_KEY";

        foreach (string line in lines)
        {
            if (line.StartsWith("CANVAS_API_KEY="))
            {
                string[] keyparts = line.Split("=", 2);
                key = keyparts[1];
            }
        }

        if (key == "NO_API_KEY")
        {
            Console.WriteLine("Error! No environment variable CANVAS_API_KEY found! Did you format the .env correctly?");
            Console.Write("Press enter to fail the program: ");
            Console.ReadLine();
        }
        
        return key;
    }

    private void AddHeaders()
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apikey}");

    }

    public Student GetStudentInfo() // TODO: Make this a Student 
    {
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/users/self/profile").Result;

        string json = response.Content.ReadAsStringAsync().Result;

        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;


        string name = root.GetProperty("name").GetString();
        string email = root.GetProperty("primary_email").GetString();
        int id = root.GetProperty("id").GetInt32();

        Student self = new Student(name,id,email);

        return self;
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

    public int CourseMenu()
    {
        

        return 1;
    }

    public void PrintCoursesJson()
    {
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/courses?enrollment_state=active&include[]=total_scores").Result;
        string json = response.Content.ReadAsStringAsync().Result;

        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        foreach (JsonElement element in root.EnumerateArray())
        {
            JsonElement enrollments = element.GetProperty("enrollments");

            
            Console.WriteLine(enrollments[0]);
        }        

    }
}