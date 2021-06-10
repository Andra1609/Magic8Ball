using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Merge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        // personURL: https://localhost:44345/
        // answerURL: https://localhost:44398/ 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // call the Person service
            var personService = "https://localhost:44345/persons";
            var personResponseCall = await new HttpClient().GetStringAsync(personService);

            // call the Answer service
            var answerService = "https://localhost:44398/answers";
            var answerResponseCall = await new HttpClient().GetStringAsync(answerService);

            var mergeResponse = $"{personResponseCall}{answerResponseCall}";
            return Ok(mergeResponse);
        }
    }
}
