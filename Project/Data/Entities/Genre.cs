namespace Project.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Film> Films { get; set; } = new();

    }
}
