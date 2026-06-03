

namespace MovieHub.Web.ViewModels;

public class CustomerForm
{
    public IEnumerable<MembershipType> MembershipTypes { get; set; }
    public Customer Customer { get; set; }
}