using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc_web_api_orders.Models
{
    public class mydbcontext:DbContext
    {
        public mydbcontext():base("constr") { }
        public DbSet<ordermodel> orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<ordermodel>().ToTable("tbl_orders");
            modelBuilder.Entity<ordermodel>().HasKey(p => p.orderid);
            modelBuilder.Entity<ordermodel>().Property(p => p.itemname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ordermodel>().Property(p => p.customermobileno).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<ordermodel>().Property(p => p.itemprice).IsRequired();
            modelBuilder.Entity<ordermodel>().Property(p => p.itemquantity).IsRequired();
        }
    }
}