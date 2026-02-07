using System;

public class Prompt
{
    public List<string> _prompts = new List<string> {"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"}; 

    public string PromptGenerator()
    {
        Random random = new Random();
        
        int randIndex = random.Next(0, _prompts.Count());

        return _prompts[randIndex];
    }
}