using Microsoft.AspNetCore.Mvc;

namespace Chir.ia_project.Controllers
{
    public class HelloWorldController : Controller
    {
        public class Example
        {
            public string Name { get; set; }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            ViewData["Payload"] = new Example { Name = name };

            return View();
        }

    }
}
