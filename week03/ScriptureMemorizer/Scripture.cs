using System;
using System.Collections.Generic;
using System.Linq;


    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            
            foreach (string word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
        }

        public string GetDisplayText()
        {
            string referenceText = _reference.GetDisplayText();
            string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{referenceText}\n\n{wordsText}";
        }

        public void HideRandomWords(int count = 1)
        {
            // Find all words that are not hidden
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0)
            {
                return; // No words left to hide
            }

           
            if (visibleWords.Count < count)
            {
                count = visibleWords.Count;
            }

            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(visibleWords.Count);
                Word wordToHide = visibleWords[index];
                wordToHide.Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        public void GiveHint()
        {
            List<Word> hiddenWords = _words.Where(w => w.IsHidden()).ToList();
            if (hiddenWords.Count > 0)
            {
                int index = _random.Next(hiddenWords.Count);
                Word wordToReveal = hiddenWords[index];
               
            }
        }

      
        public string GetHint()
        {
            List<Word> hiddenWords = _words.Where(w => w.IsHidden()).ToList();
            if (hiddenWords.Count > 0)
            {
                int index = _random.Next(hiddenWords.Count);
                Word word = hiddenWords[index];
                return $"Hint: One of the hidden words is \"{word.GetText()}\".";
            }
            return "No hints available (all words are visible).";
        }
    }
