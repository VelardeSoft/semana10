using backend01.Model;
using Microsoft.EntityFrameworkCore;

namespace backend01.Data;

public class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    } // Quedamoa aqui 38 min
}