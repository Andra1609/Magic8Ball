using Merge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Magic8Ball.Tests
{
    public class MergeControllerTest
    {
        private Mock<IConfiguration> configurationMock;
        private MergeController mergeController;

        public MergeControllerTest()
        {
            configurationMock = new Mock<IConfiguration>();
            mergeController = new MergeController(configurationMock.Object);
        }

        [Fact]
        public void GetMerge_Test()
        {
            // arrange - an instance of MergeController is created above, and is passed the configuration object

            // act
            var controllerActionResult = mergeController.Get();

            // assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<Task<IActionResult>>(controllerActionResult);
        }

    }
}
