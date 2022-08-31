// 

using Services.WebApp01.Models;

namespace Services.WebApp01;

public class Storage
{
    public static List<WorkTask> Tasks { get; set; }= new();
    public static List<Person> Persons { get; set; } = new();
}