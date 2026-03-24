using System;
using System.Collections.Generic;
using System.IO;


    class Program
    {

    //Added hint, to the program.it hints some words to the user to help them see if they can remember the rest.
        static void Main(string[] args)
        {
            // Load scriptures from file
            List<Scripture> scriptures = LoadScriptures("scriptures.txt");
            if (scriptures.Count == 0)
            {
                Console.WriteLine("No scriptures found. Please check the scriptures.txt file.");
                return;
            }

            // Select a random scripture to start
            Random random = new Random();
            Scripture currentScripture = scriptures[random.Next(scriptures.Count)];

            bool quit = false;
            while (!quit)
            {
                // Clear the console and display the current scripture
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();

                // Prompt the user
                Console.WriteLine("Press Enter to hide words, type 'hint' for a hint, or 'quit' to exit:");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "quit")
                {
                    quit = true;
                }
                else if (input == "hint")
                {
                    // Show a hint
                    string hint = currentScripture.GetHint();
                    Console.Clear();
                    Console.WriteLine(currentScripture.GetDisplayText());
                    Console.WriteLine();
                    Console.WriteLine(hint);
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
                else
                // Assume Enter was pressed (or any other input)
                {
                    // Hide a few random words (e.g., 3 words)
                    currentScripture.HideRandomWords(3);

                    // Check if all words are hidden
                    if (currentScripture.AllWordsHidden())
                    {
                        Console.Clear();
                        Console.WriteLine(currentScripture.GetDisplayText());
                        Console.WriteLine();
                        Console.WriteLine("All words are hidden! Great job memorizing!");
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to exit...");
                        Console.ReadLine();
                        quit = true;
                    }
                }
            }
        }

     
        static List<Scripture> LoadScriptures(string filePath)
        {
            List<Scripture> scriptures = new List<Scripture>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Split by the first '|' to separate reference and text
                    int separatorIndex = line.IndexOf('|');
                    if (separatorIndex < 0) continue;

                    string referencePart = line.Substring(0, separatorIndex).Trim();
                    string text = line.Substring(separatorIndex + 1).Trim();

                    // Parse the reference part
                    Reference reference = ParseReference(referencePart);
                    if (reference != null)
                    {
                        Scripture scripture = new Scripture(reference, text);
                        scriptures.Add(scripture);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading scriptures: {ex.Message}");
            }
            return scriptures;
        }

       
        static Reference ParseReference(string referenceString)
        {
            try
            {
            
                int firstSpace = referenceString.IndexOf(' ');
                if (firstSpace < 0) return null;

                string book = referenceString.Substring(0, firstSpace);
                string rest = referenceString.Substring(firstSpace + 1);

                // Now split rest by ':' to get chapter and verse(s)
                int colonIndex = rest.IndexOf(':');
                if (colonIndex < 0) return null;

                int chapter = int.Parse(rest.Substring(0, colonIndex));
                string versePart = rest.Substring(colonIndex + 1);

                // Check if versePart contains a dash for a range
                if (versePart.Contains('-'))
                {
                    string[] verses = versePart.Split('-');
                    int startVerse = int.Parse(verses[0]);
                    int endVerse = int.Parse(verses[1]);
                    return new Reference(book, chapter, startVerse, endVerse);
                }
                else
                {
                    int verse = int.Parse(versePart);
                    return new Reference(book, chapter, verse);
                }
            }
            catch
            {
                // If any parsing error occurs, return null
                return null;
            }
        }
    }
