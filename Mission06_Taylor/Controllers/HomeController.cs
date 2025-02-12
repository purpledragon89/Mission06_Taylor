using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_Taylor.Models;

namespace Mission06_Taylor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly movieContext _context;

        //  Single constructor for both logger and database context
        public HomeController(ILogger<HomeController> logger, movieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bio()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Collection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Collection(Movie model)
        {
            
            if (ModelState.IsValid)
            {
                _context.Movies.Add(model);
                _context.SaveChanges(); // Save to database
                
                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Index");
        }
    }
}