using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // call merge service
        public async Task<IActionResult> Index()
        {
            //var mergeService = "https://localhost:44356/merge";
            var mergeService = $"{Configuration["mergeServiceURL"]}/merge";
            var mergeResponseCall = await new HttpClient().GetStringAsync(mergeService);
            ViewBag.responseCall = mergeResponseCall;
            return View();
        }
    }
}
