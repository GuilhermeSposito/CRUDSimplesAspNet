using Microsoft.EntityFrameworkCore;
using TesteDeCriacaoDeApi1.Models;

namespace TesteDeCriacaoDeApi1.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Categoria> Categoria { get; set; } 
    public DbSet<Produto> Produto { get; set; } 
}
