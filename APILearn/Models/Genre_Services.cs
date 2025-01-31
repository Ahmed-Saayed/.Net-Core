
namespace APILearn.Models
{
    public class Genre_Services : IGenre_Services
    {
        private readonly DataCon con;
        public Genre_Services(DataCon con)
        {
            this.con = con;
        }
        public async Task<IEnumerable<Genre>> Get_All()
        {
            return await con.Genre.ToListAsync();
        }
        public Genre Get_Genre_ById(int id)
        {
            return con.Genre.Find(id);
        }

        public IEnumerable<Movie> GetMoviesOfGere(int id)
        {
            var ret = con.Movies.Where(o => o.GenIdForeign == id).OrderByDescending(o => o.Rate)
                .Select(o => new Movie { Id=o.Id, Title = o.Title , Rate =o.Rate,StoreLine = o.Genres_Navigation.Name})
                .ToList();

            return ret;
        }

        public Genre Add_Genre(Genre genre)
        {
            con.Genre.Add(genre);
            con.SaveChanges();

            return genre;
        }
        public Genre Update_Genre(int id, Genre gen)
        {
            var Upgenn = con.Genre.Find(id);
            Upgenn.Name = gen.Name;
            con.SaveChanges();

            return Upgenn;
        }
        public Genre Delete_Genre(int id)
        {
            var Delgenn = con.Genre.Find(id);
            
            con.Genre.Remove(Delgenn);
            con.SaveChanges();

            return Delgenn;
        }
    }
}