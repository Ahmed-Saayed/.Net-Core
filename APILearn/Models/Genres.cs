using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILearn.Models
{
    public class Genres
    {
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   to generat id automatic
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
