namespace APILearn.Models
{
    public class Create_Movie
    {
        public string Title { get; set; }
        public double Rate { get; set; }
        public string StoreLine { get; set; }
        public IFormFile Poster { get; set; }
        public int GenIdForeign { get; set; }
    }
}
