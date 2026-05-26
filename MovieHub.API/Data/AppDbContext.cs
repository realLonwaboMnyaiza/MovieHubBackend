using Microsoft.EntityFrameworkCore;
using MovieHub.API.Models;

namespace MovieHub.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Products { get; set; }
    public DbSet<Movie> Movies { get; set; }
}