using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UitoUx.DataAccess.Configurations;
using UitoUx.Domain.Models;

namespace UitoUx.DataAccess.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegisterConfiguration());
            modelBuilder.ApplyConfiguration(new HederMenuConfiguration());
        }

        public DbSet<Register> Register { get; set; }
        public DbSet<HederMenu> HederMenu { get; set; }
        public DbSet<SupMenu> supMenus { get; set; }
    }
}
