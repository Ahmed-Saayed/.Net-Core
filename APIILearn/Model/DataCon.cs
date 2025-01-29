using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIILearn.Model
{
    public class DataCon:DbContext
    {
        public DataCon(DbContextOptions options) : base(options){}

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder MB)
        {
            base.OnModelCreating(MB);

            MB.Entity<Product>().ToTable("Products");
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


    }
}
