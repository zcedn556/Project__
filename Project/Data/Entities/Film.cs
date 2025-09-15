namespace Project.Data.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public required string PosterUrl { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }


    }
}
