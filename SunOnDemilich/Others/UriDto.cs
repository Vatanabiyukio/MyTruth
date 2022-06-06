namespace SunOnDemilich.Others;

public class UriDto
{
    public string AbsoluteUri { get; set; }
    public string Authorith { get; set; }
    public string AbsolutePath { get; set; }
    private string[] Segments { get; set; }
    private bool IsFile { get; set; }

    public static UriDto Convert(Uri entity)
    {
        return new UriDto
        {
            AbsolutePath = entity.AbsolutePath,
            Authorith = entity.Authority,
            AbsoluteUri = entity.AbsoluteUri,
            Segments = entity.Segments,
            IsFile = entity.IsFile
        };
    }
}