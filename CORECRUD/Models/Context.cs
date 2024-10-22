using Microsoft.EntityFrameworkCore;

namespace CORECRUD.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\TEW_SQLEXPRESS;Database=TESTDB;User ID=sa;Password=1;Trusted_Connection=False;TrustServerCertificate=True"); 
        }

        public DbSet<Department> Department_ { get; set; }
        public DbSet<People> People_ { get; set; }
        public DbSet<User> User_ { get; set; }

        //add-migration "First-1"
        //update-database


    }
}
