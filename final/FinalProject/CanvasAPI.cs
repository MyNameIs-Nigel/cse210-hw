using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;

public class CanvasAPI
{
    // Creating the client variable
    private HttpClient _client = new HttpClient();
    
    // Protected inheritable Variables (for CanvasInfo)
    protected string _canvasUrl;
    protected int _enrollmentTermId = 419;
    protected string _apikey;

    // Constructor
    public CanvasAPI()
    {
        _apikey = APIKeyFromFile();
        _canvasUrl = "https://byui.instructure.com/api/v1";
        AddHeaders(_client);
    }

    // This method pulls your API key from the .env file in your bin
    private string APIKeyFromFile(string filename = ".env")
    {
        string[] lines = File.ReadAllLines(filename);

        string key = "NO_API_KEY";

        // Parse the .env file
        foreach (string line in lines)
        {
            if (line.StartsWith("CANVAS_API_KEY="))
            {
                string[] keyParts = line.Split("=", 2);
                key = keyParts[1];
            }
        }

        // If no api key exists...
        if (key == "NO_API_KEY")
        {
            Console.WriteLine("Error! No environment variable CANVAS_API_KEY found! Did you format the .env correctly?");
            Console.Write("Press enter to fail the program: ");
            Console.ReadLine();
        }
        
        return key;
    }

    // This is a vital method to be called in the constructor. It adds the API key for the HTTP request
    protected void AddHeaders(HttpClient client)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apikey}");

    }

    // This gets the user's info
    public Student GetStudentInfo() // TODO: Make this a Student 
    {
        // Response variable using the desired url
        HttpResponseMessage response = _client.GetAsync($"{_canvasUrl}/users/self/profile").Result;

        // json string stored into memory
        string json = response.Content.ReadAsStringAsync().Result;

        // Start the parsing of json
        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // Set the variables by parsing them
        string name = root.GetProperty("name").GetString();
        string email = root.GetProperty("primary_email").GetString();
        int id = root.GetProperty("id").GetInt32();

        // Create the Student variable and return it.
        Student self = new Student(name,id,email);
        return self;
    }

    // For debug, *Ignore*
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