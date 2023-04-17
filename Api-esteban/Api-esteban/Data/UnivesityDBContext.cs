using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_esteban.Models.DataModels;

    public class UnivesityDBContext : DbContext
    {
        public UnivesityDBContext (DbContextOptions<UnivesityDBContext> options)
            : base(options)
        {
        }

        public DbSet<Api_esteban.Models.DataModels.Chapter> Chapter { get; set; } = default!;
    }
