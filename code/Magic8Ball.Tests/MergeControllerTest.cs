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
using RichardSzalay.MockHttp;
using System.Net.Http;
using System.IO;

namespace Magic8Ball.Tests
{
    public class MergeControllerTest
    {
        private readonly IConfiguration configurationMock;
        private MergeController mergeController;

        public MergeControllerTest()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationMock = builder.Build();
        }

        [Fact]
        public async void GetMerge_Test()
        {
            // arrange
            var httpMock = new MockHttpMessageHandler();

            // when accessing the URL, get the response as type text/plain, and return that value
            httpMock.When($"{configurationMock["personServiceURL"]}/person").Respond("text/plain", "Donald Trump");
            httpMock.When($"{configurationMock["answerServiceURL"]}/answer").Respond("text/plain", "Yes.");

            // create client with the mock message handler
            var client = new HttpClient(httpMock);
            mergeController = new MergeController(configurationMock, client);

            // act
            var controllerActionResult = await mergeController.Get();
            var outcome = (string)((OkObjectResult)controllerActionResult).Value;

            // assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<OkObjectResult>(controllerActionResult);
            Assert.Equal("Donald Trump says: Yes.", outcome);
        }

    }
}
