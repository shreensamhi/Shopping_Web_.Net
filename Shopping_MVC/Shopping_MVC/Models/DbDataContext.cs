using Microsoft.EntityFrameworkCore;


namespace Shopping_MVC.Models

{
    public class DbDataContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SHREEN\\SHREENSQL;Database=SHopping_DATA;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
        }

    }
}
