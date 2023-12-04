
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<APIUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //       modelBuilder.Entity<Order>()
            //  .HasOne(o => o.Restaurant)
            //  .WithMany()
            //  .HasForeignKey(o => o.RestaurantId)
            //  .OnDelete(DeleteBehavior.Restrict);

            //       modelBuilder.Entity<Order>()
            //.HasMany(o => o.Menus)
            //.WithMany(m => m.Orders)
            //.UsingEntity(join => join.ToTable("OrderMenus")); // You can customize the join table name if needed

    //        modelBuilder.Entity<Menu>()
    //.HasOne(m => m.Restaurant)
    //.WithMany(r => r.Menu)
    //.HasForeignKey(m => m.RestaurantId)
    //.OnDelete(DeleteBehavior.Restrict);

            

        }
    }

}
