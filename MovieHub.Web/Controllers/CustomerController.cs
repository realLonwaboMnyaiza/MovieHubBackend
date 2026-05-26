using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Models;
using MovieHub.Web.ViewModels;

namespace MovieHub.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var customers = new List<Customer>();
        var john = new Customer
        {
            Id = 1,
            Name = "John"
        };
        var marry = new Customer
        {
            Id = 2,
            Name = "Marry"
        };

        customers.Add(john);
        customers.Add(marry);

        return View(customers);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
