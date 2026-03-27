using System;

class Program
{
    static void Main(string[] args)
    {
       
        Video video1 = new Video("The monk","Jack Mike", 1000000);
        Video video2 = new Video("The lords Day","John BLue", 1000000);
        Video video3 = new Video("Time","Snow Pele", 1000000);
        Video video4 = new Video("Hold me Close","Steve Will", 1000000);
        Video video5 = new Video("The monk","Jack Mike", 1000000);


         video1._comments.Add(new Comment("Grace", "Wow love your video"));
         video1._comments.Add(new Comment("Grace", "Wow love your video"));
         video1._comments.Add(new Comment("Grace", "Wow love your video"));
         video1._comments.Add(new Comment("Grace", "Wow love your video"));
         video1._comments.Add(new Comment("Grace", "Wow love your video"));
         video1._comments.Add(new Comment("Grace", "Wow love your video"));
        
        video2._comments.Add(new Comment("Grace", "Wow love your vide2"));
         video2._comments.Add(new Comment("Grace", "Wow love your vide2"));
         video2._comments.Add(new Comment("Grace", "Wow love your vide2"));
         video2._comments.Add(new Comment("Grace", "Wow love your vide2"));
         video2._comments.Add(new Comment("Grace", "Wow love your vide2"));
         video2._comments.Add(new Comment("Grace", "Wow love your vide2"));


        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);
        videos.Add(video5);


        
foreach (Video video in videos)
    {
    
        Console.WriteLine($"Title: {video._title}");
        Console.WriteLine($"Author: {video._author}");
        Console.WriteLine($"Length: {video._length} seconds");
        Console.WriteLine($"Number of Comments: {video._comments.Count}");
        
        
        foreach (Comment comment in video._comments)
        {
            Console.WriteLine($"- {comment._commenterName}: {comment._commentText}");
        }
        Console.WriteLine();
    }


    }

}