using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Infrastructure
{
    public class MinimalApiDbContext:DbContext
    {
        public MinimalApiDbContext(DbContextOptions<MinimalApiDbContext> options):base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
    }
}
