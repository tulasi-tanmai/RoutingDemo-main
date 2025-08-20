using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // Simulate fetching blog posts
            ViewData["Message"] = "Welcome to the blog!";
            return View();
        }
        [Route("archive/{year:int}/{month:int}/{day:int}")]
        public IActionResult Archive(int year, int month, int day)
        {
            // Simulate fetching blog posts by date
            ViewData["Year"] = year;
            ViewData["Month"] = month;
            ViewData["Day"] = day;
            ViewData["Message"] = $"Blog Archieve for {year}-{month:D2}-{day:D2}";
            return View();
        }
    }
}