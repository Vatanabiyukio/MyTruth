namespace SunOnDemilich.Others;

public class Image
{
    public long IdImage { get; set; }
    public DateTime DateTimeImage { get; set; }
    public UriDto Source { get; set; }
    public UriDto SourceOfFirstUseFound { get; set; }
}