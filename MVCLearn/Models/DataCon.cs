using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MVCLearn.Models
{

    public class DataCon : DbContext
    {
        public DataCon(DbContextOptions<DataCon> op) : base(op) { }

        
         protected override void OnModelCreating(ModelBuilder MB)
         {
             MB.Entity<Items>();
             MB.Entity<Items>(op =>
             {
                 op.HasIndex().IsUnique();
                 op.Property(o => o.Description).IsRequired();
             });
         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MVCData;Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
