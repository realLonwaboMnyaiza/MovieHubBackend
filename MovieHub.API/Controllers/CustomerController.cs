using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;
using System.Data.Entity;
using MovieHub.API.Models;
using System.Collections.Generic;

namespace MovieHub.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ApplicationDbContext _context;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
        _context = new ApplicationDbContext();
    }

    public IActionResult Index()
    {
        var customers = _context.Customers.Includes(c => c.MembershipType).ToList();
        return View(customers);
    }

    public IActionResult Details(int id)
    {
        var customer = _context.SingleOrDefault(c => c.Id == id);

        if (customer == null) return HttpNotFound();

        return View(customer);
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

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }
}
