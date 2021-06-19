 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Merge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        // personURL: https://localhost:44345/
        // answerURL: https://localhost:44398/ 

        private IConfiguration Configuration;

        public MergeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // call the Person service
            //var personService = "https://localhost:44345/person";
            // inject the configuration inside the controller
            var personService = $"{Configuration["personServiceURL"]}/person";
            var personResponseCall = await new HttpClient().GetStringAsync(personService);

            // call the Answer service
            //var answerService = "https://localhost:44398/answer";
            // inject the configuration inside the controller
            var answerService = $"{Configuration["answerServiceURL"]}/answer";
            var answerResponseCall = await new HttpClient().GetStringAsync(answerService);

            var mergeResponse = $"{personResponseCall} says: {answerResponseCall}";
            return Ok(mergeResponse);
        }
    }
}
