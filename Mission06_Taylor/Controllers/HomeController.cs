using System.Diagnostics;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_Taylor.Models;

namespace Mission06_Taylor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _context;

        //  Single constructor for both logger and database context
        public HomeController(ILogger<HomeController> logger, MovieContext context)
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Collection", new Movie());
        }

        [HttpPost]
        public IActionResult Collection(Movie newmovie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(newmovie);
                _context.SaveChanges();
                return View("Success", newmovie);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(newmovie);
                
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Index");
        }
        
        
        [HttpGet]
        public IActionResult CollectionView()
        {
            // Fetch movies with category info
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            // Populate categories for the dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(movies);
        }

        [HttpGet] 
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Collection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();
            return RedirectToAction("CollectionView");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedMovie)
        {
            _context.Movies.Remove(deletedMovie);
            _context.SaveChanges();
            return RedirectToAction("CollectionView");
        }
    }
}