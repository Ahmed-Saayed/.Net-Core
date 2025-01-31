using System.Collections;

namespace APILearn.Models
{
    public interface IGenre_Services
    {
        public Task<IEnumerable<Genre>> Get_All();
        public Genre Get_Genre_ById(int id);
        public IEnumerable<Movie> GetMoviesOfGere(int id);
        public Genre Add_Genre(Genre genre);
        public Genre Update_Genre(int id,Genre gen);
        public Genre Delete_Genre(int id);

    }
}
