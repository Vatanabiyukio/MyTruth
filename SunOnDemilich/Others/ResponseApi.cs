namespace SunOnDemilich.Others;

public class ResponseApi
{
    public Guid OperationId => Guid.NewGuid();
    public Pagination Pagination { get; set; }
    public IQueryable<Image> Data { get; set; }
}