public class NegativeGoal : Goal
{
    private int _timesPerformed = 0;

    public NegativeGoal(string name, string description, int points) : base(name, description, Math.Abs(points))
    {
    }

    public override int RecordEvent()
    {
        _timesPerformed++;
        return -_points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[-] {_name} ({_description}) -- Done {_timesPerformed} times (Lose {Math.Abs(_points)} points each time)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name},{_description},{_points},{_timesPerformed}";
    }
}