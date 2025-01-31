namespace APILearn.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rate { get; set; }
        public string StoreLine { get; set; }
        public byte[] Poster { get; set; }
        public int GenIdForeign { get; set; }
        public virtual Genre Genres_Navigation { get; set; }
    }
}