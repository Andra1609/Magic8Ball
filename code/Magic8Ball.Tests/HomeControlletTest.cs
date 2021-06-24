using FrontEnd.Controllers;
using FrontEnd.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Magic8Ball.Tests
{
    public class HomeControlletTest
    {
        private Mock<IConfiguration> configurationMock;
        private Mock<ILogger<HomeController>> loggerMock;
        private Mock<IRepositoryWrapper> mockRepo;
        private HomeController homeController;

        public HomeControlletTest()
        {
            loggerMock = new Mock<ILogger<HomeController>>();
            configurationMock = new Mock<IConfiguration>();
            mockRepo = new Mock<IRepositoryWrapper>();
            homeController = new HomeController(loggerMock.Object, configurationMock.Object, mockRepo.Object);
        }

        [Fact]
        public void GetMerge_Test()
        {
            // arrange - an instance of HomeController is created above, and is passed the logger and configuration objects

            // act
            var controllerActionResult = homeController.Index();

            // assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<Task<IActionResult>>(controllerActionResult);
        }

        [Fact]
        public void Outcome_Test()
        {
            // arrange
            mockRepo.Setup(repo => repo.Outcomes.FindAll()).Returns(GetOutcomes().ToList());

            // act
            var controllerActionResult = homeController.Index();

            // assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<Task<IActionResult>>(controllerActionResult);

        }

        private IEnumerable<Outcome> GetOutcomes()
        {
            var outcomes = new List<Outcome>
            {
            new Outcome(){ID=1, Response="It is Certain.", TimeAsked=DateTime.Parse("2021-06-16 14:27:38.779629")},
            new Outcome(){ID=2, Response="Don't count on it.", TimeAsked=DateTime.Parse("2021-06-16 14:27:34.766727")},
            };
            return outcomes;
        }

        [Fact]
        public void SaveToDB_Test()
        {
            // arrange
            string mergeResponseCall = "It is Certain.";
            mockRepo.Setup(repo => repo.Outcomes.Create(It.IsAny<Outcome>())).Returns(It.IsAny<Outcome>());

            // act
            homeController.SaveToDB(mergeResponseCall);

            // assert 
            mockRepo.Verify(repo => repo.Outcomes.Create(It.IsAny<Outcome>()), Times.Once());
            mockRepo.Verify(repo => repo.Save(), Times.Once());
        }


    }
}