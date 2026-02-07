using System;

public class Entry
{

    public int _entryindex;
    public string _date;
    public string _prompt;
    public string _response;


    public void Display()
    {
        Console.WriteLine($"[#{_entryindex}] - {_prompt} ({_date})");
        Console.WriteLine($"'{_response}'"); 
    }
}