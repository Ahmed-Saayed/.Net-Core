using JWT2Learn.Entites;
using Microsoft.EntityFrameworkCore;

namespace JWT2Learn.Models
{
    public class DataCon : DbContext
    {
        public DataCon(DbContextOptions<DataCon> options) : base(options){}


        public DbSet<User> Users { get; set; }
    }
}
