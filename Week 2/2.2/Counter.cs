public class Counter
{
    private int _count;
    private string _name;

    public Counter(string name)
    {
        _name = name;
        _count = 0;
    }

    public void Increment()
    {
        _count++;
    }

    public void Reset()
    {
        _count = 0;
    }

    // The value 2147483647794 exceeds the maximum value for an int in C# (2147483647)
    // This will cause an overflow compilation error.

    // public void ResetByDefault()
    // {
    //     _count = 2147483647794;
    // }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public int Ticks
    {
        get
        {
            return _count;
        }
    }
}