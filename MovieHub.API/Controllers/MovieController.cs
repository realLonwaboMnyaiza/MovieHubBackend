using Microsoft.AspNetCore.Mvc;
using MovieHub.ViewModels;

namespace MovieHub.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var movies = new List<Movie>();
        var movie1 = new Movie
        {
            Id = 1,
            Name = "Matrix"
        };
        var movie2 = new Movie
        {
            Id = 2,
            Name = "Rush Hour"
        };
        movies.Add(movie1);
        movies.Add(movie2);

        return View(movies);
    }
}
