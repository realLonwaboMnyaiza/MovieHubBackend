using System.ComponentModel.DataAnnotations;

namespace MovieHub.API.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
}