using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Intern
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    
    public DateTime StartDate { get; set; }
    public int Phone{ get; set; }
    public DateTime LogDate { get; set; }
   
    
}