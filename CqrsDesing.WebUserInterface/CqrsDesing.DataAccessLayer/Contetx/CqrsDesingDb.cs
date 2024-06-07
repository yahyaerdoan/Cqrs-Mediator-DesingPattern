using CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CqrsDesing.WebUserInterface.CqrsDesing.DataAccessLayer.Contetx
{
    public class CqrsDesingDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YAHYAERDOGAN; initial catalog=CqrsDesingDb; integrated security=true;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
