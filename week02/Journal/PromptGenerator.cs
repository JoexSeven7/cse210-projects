using System;

public class promptGenerator
{
  public List<string> _prompts; 

public string GetRandomPrompt()
    {
        _prompts = new List<string>
        {
            "Morning prayer:What are You Grateful for this morning and What Hope do You have for the day?",
            "Physical Activity:How did You Run Your day Today and how did that make you feel both mentally and physically?",
            "Self care What did you do to stay Hydrated today and how did that affect your day?",
            "Emotional Reflection: What Emotion did you experience today and how did those emotion influence your day?",
            "Evening routine: How did you spend your evening and What moment brought you peace or Enjoyment?" 
        };

        
    
       Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    }