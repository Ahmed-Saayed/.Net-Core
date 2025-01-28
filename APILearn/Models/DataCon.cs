namespace APILearn.Models
{
    public class DataCon : DbContext
    {
        public DataCon(DbContextOptions<DataCon>op):base(op){}

       public DbSet<Genres>Genre {  get; set; }

    }
}
