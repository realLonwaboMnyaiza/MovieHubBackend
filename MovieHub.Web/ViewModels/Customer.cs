using System.ComponentModel.DataAnnotations;

namespace MovieHub.Web.ViewModels;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Display(Name = "Date of Birth")]
    public Date Birthdate { get; set; }

    public bool IsSubscribed { get; set; }
    
    public MembershipType MembershipType { get; set; }
    public byte MembershipTypeId { get; set; }
}

