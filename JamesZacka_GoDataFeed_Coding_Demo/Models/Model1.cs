using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JamesZacka_GoDataFeed_Coding_Demo.Models
{
    public partial class Model1 : DbContext
    {
        public Model1(DbContextOptions<Model1> options)
            : base(options)
        { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCarts> ShoppingCarts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }

        protected override void OnConfiguring(
               DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //  .UseLazyLoadingProxies();
              //.UseSqlServer(
              //        Configuration.GetConnectionString(" ... connection string name ... "));
        }
  }
}
