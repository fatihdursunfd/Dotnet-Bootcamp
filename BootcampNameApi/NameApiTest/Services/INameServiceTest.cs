using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BootcampNameApi;
using BootcampNameApi.Services;

namespace NameApiTest.Services
{
    public class INameServiceTest
    {
        private INameService _nameService;

        public INameServiceTest()
        {
            _nameService = new NameService();
        }
        [Fact]
        public void Should_isValid_Return_False_When_ParamisEmpty()
        {
            string name = string.Empty;
            var result = _nameService.isValid(name);
            Assert.False(result);
        }

        [Fact]
        public void Should_isValid_Return_True_When_ParamisnotEmpty()
        {
            string name = "fatih";
            var result = _nameService.isValid(name);
            Assert.True(result);
        }
    }
}
