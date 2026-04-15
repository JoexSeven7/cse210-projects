public class Goal
{
    protected string _name = "";
    protected string _description = "";
    protected int _points = 0;
    protected bool _isComplete = false;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual bool IsComplete()
    {
        return _isComplete;
    }

    public virtual string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_name},{_description},{_points},{_isComplete}";
    }

    public string GetName() => _name;
    public int GetPoints() => _points;
}