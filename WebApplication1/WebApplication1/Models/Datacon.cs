using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class Datacon : DbContext
    {
        public Datacon() : base() { }
        public Datacon(DbContextOptions options) : base(options) { }
        public DbSet<Department> Departments { get; set; }      // Table
        public DbSet<Students> Students { get; set; }          // Table
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7BQRJTH;Initial Catalog=PATO ;Integrated Security=True;TrustServerCertificate=True");     // open vedio 3 from min 51 !!
            base.OnConfiguring(optionsBuilder);
        }
    }
}
