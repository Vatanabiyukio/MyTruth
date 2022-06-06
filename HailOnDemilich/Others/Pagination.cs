namespace HailOnDemilich.Others;

public class Pagination
{
    private const int MaxPageSize = 50;
    private int _size = 10;
    private int _number = 1;

    public int PageNumber
    {
        get => _number;
        set => _number = value < 2 ? 1 : value;
    }

    public int PageSize
    {
        get => _size;
        set
        {
            _size = value switch
            {
                > MaxPageSize => MaxPageSize,
                < 1 => 1,
                _ => value
            };
        }
    }
}