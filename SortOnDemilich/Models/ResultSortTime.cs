using System.Diagnostics;

namespace SortOnDemilich.Models;

public class ResultSortTime
{
    public Guid Id => Guid.NewGuid();
    public string Algorithm { get; set; }
    public int Length { get; set; }
    public long Duration { get; set; }
}