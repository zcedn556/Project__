using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;

public class FilmsDbContext : IdentityDbContext<ApplicationUser>
{
    public FilmsDbContext(DbContextOptions<FilmsDbContext> options)
        : base(options) { }

    public DbSet<Film> Films { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(new List<Genre>()
        {
            new() { Id = 1, Name = "Action" },
            new() { Id = 2, Name = "Comedy" },
            new() { Id = 3, Name = "Drama" },
            new() { Id = 4, Name = "Horror" },
            new() { Id = 5, Name = "Sci-Fi" },
            new() { Id = 6, Name = "Romance" },
            new() { Id = 7, Name = "Thriller" },
            new() { Id = 8, Name = "Animation" },
            new() { Id = 9, Name = "Documentary" }
        });

        modelBuilder.Entity<Film>().HasData(new List<Film>()
        {
            new() { Id = 1, Title = "Inception", GenreId = 5, Year = 2010, Rating = 8.8, PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_FMjpg_UX1000_.jpg" },
            new() { Id = 2, Title = "The Dark Knight", GenreId = 1, Year = 2008, Rating = 9.0, PosterUrl = "https://play-lh.googleusercontent.com/auIs5tjWlLYaFPGClZOJ7m5YVbnX6uBvz0X02r8TkwFKdzE53ww2MqWSS9gU0YNqoYwvpg" },
            new() { Id = 3, Title = "Forrest Gump", GenreId = 3, Year = 1994, Rating = 8.8, PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_.jpg" },
            new() { Id = 4, Title = "Interstellar", GenreId = 5, Year = 2014, Rating = 8.6, PosterUrl = "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_.jpg" },
            new() { Id = 5, Title = "Shrek", GenreId = 8, Year = 2001, Rating = 7.9, PosterUrl = "https://m.media-amazon.com/images/I/51G1sZl8Y-L._AC_.jpg" },
            new() { Id = 6, Title = "Titanic", GenreId = 6, Year = 1997, Rating = 7.8, PosterUrl = "https://m.media-amazon.com/images/I/51rOnIjLqzL._AC_.jpg" },
            new() { Id = 7, Title = "Get Out", GenreId = 4, Year = 2017, Rating = 7.7, PosterUrl = "https://m.media-amazon.com/images/I/91Vh3fQy8WL._AC_SY679_.jpg" }
        });
    }
}
