using System.Collections.Generic;
public class Video
{
   public string _title;
   public string _author;
   public int _length;
   public List<Comment> _comments;


   public Video (string title, string author, int length)
    {
      _title = title;
      _author = author;
      _length = length;
      _comments = new List<Comment>(); 
    }
   

   public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberofComments()
    {
        return _comments.Count;
    }

     public string GetTitle()
    {
        return _title;
    }
    public string GetAuthor() {
        return _author;
        }
    public int GetLength()
    {
        return _length;
    }
}