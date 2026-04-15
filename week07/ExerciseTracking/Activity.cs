using System;

public class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        return string.Format("{0:dd MMM yyyy} {1} ({2} min)- Distance {3:F1} km, Speed {4:F1} kph, Pace: {5:F2} min per km", 
            _date, this.GetType().Name, _minutes, distance, speed, pace);
    }
}