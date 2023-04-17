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
    public DbSet<Course>? Cousers { get; set; }
    public DbSet<Chapter>? Chapters{ get; set; }
    public DbSet<Category>? Categories{ get; set; }
    public DbSet<Student>? Students{ get; set; }
}