using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class StoreConnection : DbContext
    {
       public DbSet<Student> student { get; set; }

       public DbSet<House> house { get; set; }

       public DbSet<Roles> role { get; set; }
       public DbSet<User> user { get; set; }
    }
}