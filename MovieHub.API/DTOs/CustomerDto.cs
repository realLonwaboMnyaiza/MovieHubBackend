
namespace MovieHub.API.DTO;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public bool IsSubscribed { get; set; }

    public byte MembershipTypeId { get; set; }
    // public MembershipType MembershipType { get; set; }
}