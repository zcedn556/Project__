using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Sci-Fi" },
                    { 6, "Romance" },
                    { 7, "Thriller" },
                    { 8, "Animation" },
                    { 9, "Documentary" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "GenreId", "PosterUrl", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 5, "https://m.media-amazon.com/images/I/51kzmpH0ZDL._AC_SY679_.jpg", 8.8000000000000007, "Inception", 2010 },
                    { 2, 1, "https://m.media-amazon.com/images/I/51Qvs9i5a%2BL._AC_.jpg", 9.0, "The Dark Knight", 2008 },
                    { 3, 3, "https://m.media-amazon.com/images/I/41cW57Qd5CL._AC_.jpg", 8.8000000000000007, "Forrest Gump", 1994 },
                    { 4, 5, "https://m.media-amazon.com/images/I/71niXI3lxlL._AC_SL1024_.jpg", 8.5999999999999996, "Interstellar", 2014 },
                    { 5, 8, "https://m.media-amazon.com/images/I/51G1sZl8Y-L._AC_.jpg", 7.9000000000000004, "Shrek", 2001 },
                    { 6, 6, "https://m.media-amazon.com/images/I/51rOnIjLqzL._AC_.jpg", 7.7999999999999998, "Titanic", 1997 },
                    { 7, 4, "https://m.media-amazon.com/images/I/91Vh3fQy8WL._AC_SY679_.jpg", 7.7000000000000002, "Get Out", 2017 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
