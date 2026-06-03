using System;
using System.ComponentModel.DataAnnotations;

namespace MovieHub.Web.ViewModels;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Number in Stock")]
    public byte NumberInStock { get; set; }

    [Required]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}