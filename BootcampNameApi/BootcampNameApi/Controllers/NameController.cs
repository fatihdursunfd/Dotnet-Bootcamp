using BootcampNameApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampNameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : Controller
    {
        private readonly INameService _nameService;

        public NameController(INameService nameService)
        {
            _nameService = nameService;
        }

        [Route("alive")]
        [HttpGet]
        public IActionResult Alive()
        {
            return Content("Api alive");
        }

        [HttpGet]
        public StatusCodeResult Get(string name)
        {
            var isValidName = _nameService.isValid(name);
            if (isValidName)
                return Ok();
            else
                return BadRequest();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
