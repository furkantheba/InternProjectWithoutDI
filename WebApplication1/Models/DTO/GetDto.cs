namespace WebApplication1.Models.DTO;

public class GetDto
{
    public string? name { get; set; }
    public string? surname { get; set; }
    public int page { get; set; } = 1;
    public int pageSize { get; set; } = 10;

}