using System;

public class MathAssignment : Assignment
{
   private string _textbookSection = "";
   private string _problem = ""; 


   public MathAssignment (string studentName, string topic, string textbookSection, string problem  ) : base (topic, studentName)
    {
        _textbookSection = textbookSection;
        _problem = problem;

    }


  public string GetTextBook()
  {
  return _textbookSection;
  }

  public void SetTextBook(string textbook)
  {
    _textbookSection = textbook;
  }

  public string GetProblem()
    {
        return _problem;
    }


    public void SetProblem(string problem)
    {
        _problem = problem;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problem}";
    }

}