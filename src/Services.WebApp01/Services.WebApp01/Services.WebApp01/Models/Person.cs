// 

using System.ComponentModel.DataAnnotations;

namespace Services.WebApp01.Models;

public class Person
{
        
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}