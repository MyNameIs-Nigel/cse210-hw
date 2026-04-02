using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;

public class CanvasAPI
{
    private HttpClient _client = new HttpClient();
    

    protected string _canvasUrl;
    protected int _enrollmentTermId = 419;
    protected string _apikey;
    public CanvasAPI()
    {
        _apikey = APIKeyFromFile();
        _canvasUrl = "https://byui.instructure.com/api/v1";
        AddHeaders(_client);
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

    protected void AddHeaders(HttpClient client)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apikey}");

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