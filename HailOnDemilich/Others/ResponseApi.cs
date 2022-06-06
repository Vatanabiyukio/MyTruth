namespace HailOnDemilich.Others;

public class ResponseApi
{
    public Guid OperationId => Guid.NewGuid();
    public Pagination Pagination { get; set; }
    public IQueryable<object> Data { get; set; }
}