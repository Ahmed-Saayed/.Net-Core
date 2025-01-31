namespace APILearn.Models
{
    public class DataCon : DbContext
    {
       public DataCon(DbContextOptions<DataCon>op):base(op){}

       public DbSet<Genre>Genre {  get; set; }
       public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder MP)
        {
            base.OnModelCreating(MP);

            MP.Entity<Movie>().HasOne(o => o.Genres_Navigation).WithMany(o => o.LstOfMovies)
                .HasForeignKey(o => o.GenIdForeign).HasPrincipalKey(o=>o.Id);
        }

    }
}
