using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCar1.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> option) : base(option)
        {

        }


        public DbSet<Person> person { set; get; }

        public DbSet<Car> car { set; get; }
    }
}
