using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILearn.Models
{
    public class Genre
    {
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   to generat id automatic
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<Movie>? LstOfMovies { get; set; }
    }
}
