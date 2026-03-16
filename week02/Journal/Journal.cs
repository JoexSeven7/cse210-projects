using System;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
             Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }


     public void SaveToFile(string filename)
    {
         List<string> lines = new List<string>();
         foreach (Entry entry in _entries)
        {
            lines.Add($"{entry._date}|{entry._promptText}|{entry._entryText}");
        }

        File.WriteAllLines(filename, lines);    

        Console.WriteLine($"Journal saved to {filename}");
    }


     public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from {filename}");
    }

}