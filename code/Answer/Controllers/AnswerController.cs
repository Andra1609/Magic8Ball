using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Answer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        private static readonly string[] Answers = new[]
        {
            //"It is certain.", "It is decidedly so.", "Without a doubt.", "Yes definitely.", "You may rely on it.",
            //"As I see it, yes.", "Most likely.", "Outlook good.", "Yes.", "Signs point to yes.",
            //"Don't count on it.", "My reply is no.", "My sources say no.", "Outlook not so good.", "Very doubtful..."
            "Reply hazy, try again.", " Ask again later.", "Better not tell you now.", "Cannot predict now.", "Concentrate and ask again."
        };
       
        [HttpGet]
        public ActionResult<string> Get()
        {
            var rand = new Random();
            var index = rand.Next(0, 15);
            //var index = rand.Next(0, 5);

            return Answers[index].ToString();
        }
    }
}
