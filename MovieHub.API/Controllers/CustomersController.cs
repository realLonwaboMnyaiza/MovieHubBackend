using MovieHub.API.Data;
using MovieHub.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieHub.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context, ILogger<CustomerController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        return customers;
    }

    [HttpGet]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer is null)
            return NotFound();

        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        _context.Customers.Add(customer);
        _context.SaveChanges();

        return customer;
    }

    [HttpPut]
    public ActionResult<Customer> EditCustomer(int id, Customer customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        // todo: use auto mapper. 
        var savedCustomer = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

        if (savedCustomer is null)
            return NotFound();

        savedCustomer.Name = customer.Name;
        savedCustomer.Birthdate = customer.Birthdate;
        savedCustomer.MembershipTypeId = customer.MembershipTypeId;
        savedCustomer.IsSubscribed = customer.IsSubscribed;

        _context.SaveChanges();

        return customer;
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteCustomer(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer is null)
            return NotFound();

        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return customer;
    }
}
