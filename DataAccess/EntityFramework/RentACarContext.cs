using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class RentACarContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//overrride on tab tab
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = RentACar; Trusted_Connection = true");
            //projeyi oluşturmuş olduğum Database'le ilişkilendirdim.
        }
        public DbSet<Car> Cars { get; set; }//Car ve diğer diğer iki classı database'İmizin  ilgili tabloları ile ilşkilendirdik.
        public DbSet<Brand> Brands { get; set; } 
        public DbSet<Color> Colors { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
