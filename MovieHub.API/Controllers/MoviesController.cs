using MovieHub.API.Data;
using MovieHub.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieHub.Controllers;

public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly ApplicationDbContext _context;

    public MovieController(ApplicationDbContext context, ILogger<MovieController> logger)
    {
        _logger = logger;
        _context = context;
    }
}
