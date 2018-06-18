using Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=School")
        {
        }

        public DbSet<Location> Location { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }
    }
}

