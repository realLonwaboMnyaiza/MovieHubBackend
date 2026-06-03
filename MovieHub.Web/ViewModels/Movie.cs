using System.ComponentModel.DataAnnotations;

namespace MovieHub.Web.ViewModels;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
}