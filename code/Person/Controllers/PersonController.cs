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
            "Barack Obama", "Donald Trump", "Boris Johnson"
        };
         
        [HttpGet]
        public ActionResult<String> Get()
        {
            var rand = new Random();
            var index = rand.Next(0,3);
            return Person[index].ToString();
        }
    }
}
