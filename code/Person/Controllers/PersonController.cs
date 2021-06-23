using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Person.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static readonly string[] Person = new[]
        {
            //"Barack Obama", "Donald Trump", "Hillary Clinton", "Boris Johnson", "Vladimir Putin",
            //"Justin Trudeau", "Klaus Iohannis", "Nicolas Sarkozy", "Angela Merkel", "Joe Biden"
            "Tom Cruise", "Nicole Kidman", "Tom Hanks", "Morgan Freeman", "Johnny Depp",
            "Denzel Washington", "Meryl Streep", "Charlize Theron", "Helena Bonham Carter", "Jennifer Connelly"
        };
         
        [HttpGet]
        public ActionResult<String> Get()
        {
            var rand = new Random();
            var index = rand.Next(0,10);
            return Person[index].ToString();
        }
    }
}
