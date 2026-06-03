using MovieHub.API.Data;
using MovieHub.API.Models;
using MovieHub.API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MovieHub.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ApplicationDbContext context, IMapper mapper, ILogger<CustomerController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<CustomerDto> GetCustomers()
    {
        var customers = _context.Customers
                        .Include(c => c.MembershipType).ToList()
                        .Select(c => _mapper.Map<CustomerDto>(c));
        return customers;
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<CustomerDto> GetCustomer(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer is null)
            return NotFound();

        return _mapper.Map<CustomerDto>(customer);
    }

    [HttpPost]
    public ActionResult<CustomerDto> CreateCustomer(CustomerDto customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        _context.Customers.Add(_mapper.Map<Customer>(customer));
        _context.SaveChanges();

        return customer;
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<CustomerDto> EditCustomer(CustomerDto customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var savedCustomer = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

        if (savedCustomer is null)
            return NotFound();

        _mapper.Map<Customer>(customer);

        _context.SaveChanges();

        return _mapper.Map<CustomerDto>(savedCustomer);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<CustomerDto> DeleteCustomer(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customer is null)
            return NotFound();

        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return _mapper.Map<CustomerDto>(customer);
    }
}
