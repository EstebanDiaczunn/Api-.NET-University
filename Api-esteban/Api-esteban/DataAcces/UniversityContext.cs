using Api_esteban.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Api_esteban.DataAccess;

public class UniversityDBContext : DbContext
{
    public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
    {
        
    }
    // TODO: Add DbSets (tables of our data base)
    public DbSet<User>? Users { get; set; }
    
}