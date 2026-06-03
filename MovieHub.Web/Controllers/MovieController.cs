using Microsoft.AspNetCore.Mvc;
using MovieHub.Web.ViewModels;

namespace MovieHub.Web.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private IList<Movie> movies;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var movie1 = CreateMovie(1, "Matrix");
        var movie2 = CreateMovie(2, "Rush Hour");

        movies.Add(movie1);
        movies.Add(movie2);

        return View(movies);
    }

    public IActionResult NewMovie()
    {
        var genres = GetMovieGenres();
        var viewModel = new MovieForm
        {
            Genres = genres
        };

        return View("MovieForm", genres);
    }

    public IActionResult EditMovie(int id)
    {
        var movie = movies.SingleOrDefault(c => c.Id == id);

        if (movie is null) return NotFound();

        var viewModel = new MovieForm
        {
            Movie = movie,
            Genres = GetMovieGenres()
        };

        return View("MovieForm", viewModel);
    }

    [HttpPost]
    public IActionResult SubmitMovieForm(MovieForm movieForm)
    {
        if (!ModelState.IsValid)
        {
            return View("MovieForm", movieForm);
        }
        return RedirectToAction("Index", "Movie");
    }

    static private Movie CreateMovie(int id, string name)
    {
        return new Movie
        {
            Id = id,
            Name = name,
        };
    }


    static private IList<Genre> GetMovieGenres()
    {
        var genres = new List<Genre>()
        {
            new Genre
            {
                Id = 1,
                Name= "Action"
            },
            new Genre
            {
                Id = 2,
                Name= "Sci-Fi"
            },
        };
        return genres;
    }
}
