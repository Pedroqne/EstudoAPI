using EstudoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Funcionario> Funcionarios { get; set; }



}
