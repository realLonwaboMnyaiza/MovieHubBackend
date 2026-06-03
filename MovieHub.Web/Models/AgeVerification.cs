
namespace MovieHub.Web.Models;

public class AgeVerification : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var customer = validationContext.ObjectInstance as Customer;

        if (customer.MembershipTypeId == MembershipType.Unknown 
            || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            return ValidationResult.Success;

        if (customers.Birthdate is null)
            return new ValidationResult("Birthdate is required.");

        var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

        return (age >= 18) 
            ? ValidationResult.Success 
            : new ValidationResult("Customer must meet age verification requirements to register as a member.")
    }
}