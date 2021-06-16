using FrontEnd.Controllers;
using FrontEnd.Interfaces;
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
;       }

        [Fact]
        public void GertMerge_Test()
        {
            // arrange - an instance of HomeController is created above, and is passed the logger and configuration objects
            // act
            var controllerActionResult = homeController.Index();

            // assert
            Assert.NotNull(controllerActionResult);
        }
    }
}
