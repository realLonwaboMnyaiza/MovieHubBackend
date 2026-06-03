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

    public IActionResult EditCustomer(int id)
    {
        var customers customers.SingleOrDefault(c => c.id == id);

        if (customer is null) return HttpNotFound();

        var viewModel = new MovieForm
        {
            Customer = customer,
            Genres = GetMovieGenres()
        };

        return View("MovieForm", viewModel);
    }

    [HttpPost]
    public IActionResult SubmitMovieForm(MovieForm movie)
    {
        return RedirectToAction("Index", "Movie");
    }

     static private Customer CreateMovie(int id, string name) 
    {
       return new Customer
        {
            Id = id,
            Name = name, 
        }; 
    }


    static private IList<Genres> GetMovieGenres()
    {
        var genres = new List()
        {
            new Genres
            {
                Id = 1,
                Name= "Action"
            },
            new Genres
            {
                Id = 2,
                Name= "Sci-Fi"
            },
        };
        return genres;
    }
}
