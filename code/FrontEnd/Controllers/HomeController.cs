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
using FrontEnd.Interfaces;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;
        private IRepositoryWrapper repository;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IRepositoryWrapper repositorywrapper)
        {
            _logger = logger;
            Configuration = configuration;
            repository = repositorywrapper;
        }

        // call merge service
        public async Task<IActionResult> Index()
        {
            //var mergeService = "https://localhost:44356/merge";
            var mergeService = $"{Configuration["mergeServiceURL"]}/merge";
            var mergeResponseCall = await new HttpClient().GetStringAsync(mergeService);
            ViewBag.responseCall = mergeResponseCall;

            // add outcome from services to database
            var outcome = new Outcome
            {
                Outcomes = mergeResponseCall
            };
            repository.Outcomes.Create(outcome);
            repository.Save();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
