using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    ImageFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageMimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.).", "Action" },
                    { 2, "An adventure story is about a protagonist who journeys to epic or distant places to accomplish something. It can have many other genre elements included within it, because it is a very open genre.", "Adventure" },
                    { 3, "Technically speaking, animation is more of a medium than a film genre in and of itself; as a result, animated movies can run the gamut of traditional genres with the only common factor being that they don’t rely predominantly on live action footage.", "Animation" },
                    { 4, "Comedy is a story that tells about a series of funny or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basis.", "Comedy" },
                    { 5, "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. The stereotypical plot line follows the boy-gets-girl, boy-loses-girl, boy gets girl back again sequence. ", "Romantic Comedy" },
                    { 6, "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. ", "Crime" },
                    { 7, "Within film, television and radio (but not theatre), drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone,", "Drama" },
                    { 8, "Science fiction is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. ", "Sci-Fi" },
                    { 9, "Romance novels are emotion-driven stories that are primarily focused on the relationship between the main characters of the story.", "Romance" },
                    { 10, "A fantasy story is about magic or supernatural forces, rather than technology, though it often is made to include elements of other genres, such as science fiction elements, for instance computers or DNA, if it happens to take place in a modern or future era. ", "Fantasy" },
                    { 11, "The coverage of sports as a television program, on radio and other broadcasting media. It usually involves one or more sports commentators describing the events as they happen, which is called colour commentary.", "Sport" },
                    { 12, "Stories in the Western genre are set in the American West, between the time of the Civil war and the early nineteenth century.", "Western" },
                    { 13, "A Thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. ", "Thriller" },
                    { 14, "The family saga is a genre of literature which chronicles the lives and doings of a family or a number of related or interconnected families over a period of time. ", "Family" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Director", "GenreID", "Gross", "ImageFile", "ImageMimeType", "ImageUrl", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 9, "Christopher Nolan", 1, 533316061m, null, null, null, 9.0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 7, "Quentin Tarantino", 13, 107930000m, null, null, null, 8.9000000000000004, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { 4, "Howard Hawks", 12, 5750000m, null, null, null, 8.0999999999999996, new DateTime(1959, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio Bravo" },
                    { 15, "Stanley Kubrick", 8, 56715371m, null, null, null, 8.3000000000000007, new DateTime(1968, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001: A Space Odyssey" },
                    { 12, "The Wachowski Brothers", 8, 171383253m, null, null, null, 8.6999999999999993, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 8, "Steven Spielberg", 7, 96067179m, null, null, null, 8.9000000000000004, new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindlers List" },
                    { 6, "Francis Ford Coppola", 7, 134821952m, null, null, null, 9.1999999999999993, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 16, "Robert Zemeckis", 14, 210609762m, null, null, null, 8.5, new DateTime(1989, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back to the Future" },
                    { 5, "Frank Darabont", 7, 28341469m, null, null, null, 9.3000000000000007, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 14, " Terry Gilliam & Terry Jones", 4, 1229197m, null, null, null, 8.3000000000000007, new DateTime(1975, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monty Python and the Holy Grail" },
                    { 13, "Robert Zemeckis", 4, 329691196m, null, null, null, 8.8000000000000007, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 3, "Ivan Reitman", 4, 112494738m, null, null, null, 6.5, new DateTime(1986, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters 2" },
                    { 2, "Ivan Reitman", 4, 13612564m, null, null, null, 6.5, new DateTime(1984, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters" },
                    { 11, "George Lucas", 1, 460935665m, null, null, null, 8.6999999999999993, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars" },
                    { 10, "Peter Jackson", 1, 377019252m, null, null, null, 8.9000000000000004, new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings" },
                    { 1, "Rob Reiner", 5, 92823600m, null, null, null, 7.5999999999999996, new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "When Harry Met Sally" },
                    { 17, "Pete Docter & David Silverman", 14, 289907418m, null, null, null, 8.0999999999999996, new DateTime(2001, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monsters Inc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID",
                table: "Movies",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
