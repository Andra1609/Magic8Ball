using Answer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Magic8Ball.Tests
{
    public class AnswerControllerTest
    {
        [Fact]
        public async Task GetAnswer_Test()
        {
            // arrange
            var answerController = new AnswerController();

            // act
            var controllerActionResult = answerController.Get();

            // assert
            Assert.NotNull(controllerActionResult);
        }
    }
}
