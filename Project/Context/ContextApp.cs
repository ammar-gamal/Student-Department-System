using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Models;
using System;
using System.Xml;

namespace Project.Context
{
    public class ContextApp:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str= "Server = .;Database = Project; Trusted_Connection = True; Encrypt=False  ";
            optionsBuilder.UseSqlServer(str);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   modelBuilder.Entity<Student>()
            //.Property(e => e.DoB)
            //.IsRequired() // Ensures the property is required
            //.HasCheckConstraint("CK_DateRange", "DATEDIFF(YEAR, YourDateTimeProperty, GETDATE()) BETWEEN 20 AND 30");
            modelBuilder.Entity<Student>().Property(e => e.DoB).IsRequired();
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
