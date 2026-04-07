public class WritingAssignment : Assignment
{
    private string _title = "";


    public WritingAssignment (string title, string studentName, string topic ) : base(studentName, topic)
    {
    _title = title;
    }

   public string GetTitle()
  {
  return _title;
  }

  public void SetTitle(string title)
  {
    _title = title;
  }

   public string GetWritingInformation()
    {
        return _title;
    }
}