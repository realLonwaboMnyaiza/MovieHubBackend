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

    [HttpGet]
    public IActionResult HydrateCustomerForm()
    {
        var membershipTypes = _context.MembershipTypes.ToList();
    }

    [HttpPost]
    public IActionResult CreateCustomer(Customer customer) 
    {
       _context.Customers.Add(customer);
       _context.SaveChanges();
    }

    public IActionResult EditCustomer(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.id == id);

        if (customer is null) return HttpNotFound();
    }

    public IActionResult Details(int id)
    {
        var customer = _context.SingleOrDefault(c => c.Id == id);

        if (customer == null) return HttpNotFound();

        return View(customer);
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }
}
