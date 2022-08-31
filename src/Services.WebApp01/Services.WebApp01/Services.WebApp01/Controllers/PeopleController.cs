// 

using Microsoft.AspNetCore.Mvc;
using Services.WebApp01.Models;

namespace Services.WebApp01.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
   [HttpGet(Name = "GetAll")]
    public IEnumerable<Person> Get()
    {
        return Storage.Persons;
    }

    [HttpPost(Name = "Create")]
    public void Post(Person person)
    {
        Storage.Persons.Add(person);
    }
}