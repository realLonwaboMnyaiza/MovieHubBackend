namespace MovieHub.Web.ViewModels;

public class MembershipType 
{
   public byte Id { get; set; }
   [Required]
   public string Name { get; set; }
   public short SignUpFee { get; set;}
   public byte DurationInMonths { get; set; }
   public byte DiscountRate { get; set; }

   // note: does not need to be enum, we only need a subset of the values to 
   // remove magic strings.
   public static readonly byte Unknown = 0;
   public static readonly byte PayAsYouGo = 1;
}