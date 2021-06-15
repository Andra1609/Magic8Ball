using FrontEnd.Controllers;
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
    public class FrontEndTest
    {
        private Mock<IConfiguration> configurationMock;
        private Mock<ILogger<HomeController>> loggerMock;
        private HomeController homeController;

        public FrontEndTest()
        {
            configurationMock = new Mock<IConfiguration>();
            loggerMock = new Mock<ILogger<HomeController>>();
            homeController = new HomeController(loggerMock.Object, configurationMock.Object);
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
