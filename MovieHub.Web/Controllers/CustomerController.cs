using System.Text;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Web.Models;
using MovieHub.Web.ViewModels;

namespace MovieHub.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    private static IList<Customer> customers;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var customer1 = CreateCustomer(1, "John");
        var customer2 = CreateCustomer(2, "Marry");

        customers.Add(customer1);
        customers.Add(customer2);

        return View(customers);
    }


    public IActionResult NewCustomer()
    {
        var membershipTypes = GetMembershipTypes();
        var viewModel = new CustomerForm
        {
            MembershipTypes = membershipTypes,
        }

        return View("CustomerForm", membershipTypes);
    }

    public IActionResult EditCustomer(int id)
    {
        var customer = customers.SingleOrDefault(c => c.id == id);

        if (customer is null) return HttpNotFound();

        var viewModel = new CustomerForm
        {
            Customer = customer,
            MembershipTypes = GetMembershipTypes()
        };

        return View("CustomerForm", viewModel);
    }

    [HttpPost]
    public IActionResult SubmitCustomerForm(CustomerForm customerForm) 
    {
        if (!ModelState.IsValid)
        {
            return View("CustomerForm", customerForm);
        }
        return RedirectToAction("Index", "Customer");
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


    static private Customer CreateCustomer(int id, string name) 
    {
       return new Customer
        {
            Id = id,
            Name = name, 
        }; 
    }


    static private IList<MembershipType> GetMembershipTypes()
    {
        var membershipTypes = new List();
        var basicPlan = new MembershipType
        {
            Id = 1,
            SignUpFee = 0,
            DurationInMonths = 0,
            DiscountRate = 0
        };
        membershipTypes.add(basicPlan);
        return membershipTypes;
    }
}
