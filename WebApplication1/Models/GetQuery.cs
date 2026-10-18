namespace WebApplication1.Models;

public class GetQuery
{
    public string? name { get; set; }
    public string? surname { get; set; }
    public int page { get; set; } = 1;
    public int pageSize { get; set; } = 10;
}