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
            "Yes", "Yes, absolutely", "It is certain", "It is decidely so", "Without a doubt",
            "No", "No way", "Very doubtful", "Don't count on it", "My sources say no"
        };

        //// v2
        //private static readonly string[] Summaries = new[]
        //{
        //    "Ask again later", "Cannot predict right now", "Better not to tell you"
        //};
       
        [HttpGet]
        public ActionResult<string> Get()
        {
            var rand = new Random();
            var index = rand.Next(0, 10);
            //// v2
            //var index = rand.Next(0, 4);
            return Answers[index].ToString();
        }
    }
}
