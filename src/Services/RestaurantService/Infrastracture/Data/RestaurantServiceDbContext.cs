using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;




namespace Infrastracture.Data
{
    public class RestaurantServiceDbContext : DbContext
    {
        public RestaurantServiceDbContext(DbContextOptions<RestaurantServiceDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuItem>()
            .Property(propertyExpression => propertyExpression.Price).
            HasPrecision(18, 2);

            builder.Entity<Menu>().Property(propertyExpression => propertyExpression.Price).HasPrecision(18, 2);

            base.OnModelCreating(builder);

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }






    }


}