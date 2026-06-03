
using System.ComponentModel.DataAnnotations;
using MovieHub.Web.ViewModels;

namespace MovieHub.Web.Models;

public class AgeVerification : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        var customer = (Customer)validationContext.ObjectInstance;

        if (customer.MembershipTypeId == MembershipType.Unknown
            || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            return ValidationResult.Success;

        if (customer.Birthdate is null)
            return new ValidationResult("Birthdate is required.");

        var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

        var result = default(ValidationResult);
        if (age >= 18)
            result = ValidationResult.Success;
        else
            result = new ValidationResult("Customer must meet age verification requirements to register as a member.");

        return result;
    }
}