using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampNameApi.Services;
using BootcampNameApi.Controllers;
using Moq;
using Xunit;
using System.Net;

namespace NameApiTest.Endpoint
{
    public class NameControllerTest
    {
        private readonly Mock<INameService> _nameService;

        private readonly NameController _nameControler;

        private readonly string name;


        public NameControllerTest()
        {
            name = string.Empty;
            _nameService = new Mock<INameService>();
            _nameControler = new NameController(_nameService.Object);
        }

        [Fact]
        public void Should_Get_Return_StatusCode200_When_NameService_isValid_Returns_True()
        {
            _nameService.Setup(i => i.isValid(It.IsAny<string>())).Returns(true);
            var result = _nameControler.Get(name);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Should_Get_Return_StatusCode400_When_NameService_isValid_Returns_False()
        {
            _nameService.Setup(i => i.isValid(It.IsAny<string>())).Returns(false);
            var result = _nameControler.Get(name);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
