using Person.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Magic8Ball.Tests
{
    public class PersonControllerTest
    {
        [Fact]
        public async Task GetPerson_Test()
        {
            // arrange
            var personController = new PersonController();

            // act
            var controllerActionResult = personController.Get();

            // assert
            Assert.NotNull(controllerActionResult);
        }
    }
}