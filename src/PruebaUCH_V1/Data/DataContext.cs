using Microsoft.EntityFrameworkCore;
using PruebaUCH_V1.Models;
using System.Collections.Generic;

namespace PruebaUCH_V1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Properties> Properties { get; set; }
    }
}
