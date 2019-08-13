using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public CheeseDbContext(DbContextOptions<CheeseDbContext> options) : base(options)
        {

        }

        public DbSet<CheeseMVC.Models.Cheese> Cheeses { get; set; }
        public DbSet<CheeseMVC.Models.CheeseCategory> Categories { get; set; }
        public DbSet<CheeseMVC.Models.Menu> Menus { get; set; }
        public DbSet<CheeseMVC.Models.CheeseMenu> CheeseMenus { get; set; }



        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }
        
          
    }
}
