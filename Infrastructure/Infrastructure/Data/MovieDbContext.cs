﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //var genres = new List<Genre>
            //{
            //    new Genre { GenreID = 1, Name = "Action", Description = "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.)." },
            //    new Genre { GenreID = 2, Name = "Adventure", Description = "An adventure story is about a protagonist who journeys to epic or distant places to accomplish something. It can have many other genre elements included within it, because it is a very open genre." },
            //    new Genre { GenreID = 3, Name = "Animation", Description = "Technically speaking, animation is more of a medium than a film genre in and of itself; as a result, animated movies can run the gamut of traditional genres with the only common factor being that they don’t rely predominantly on live action footage." },
            //    new Genre { GenreID = 4, Name = "Comedy", Description = "Comedy is a story that tells about a series of funny or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basis." },
            //    new Genre { GenreID = 5, Name = "Romantic Comedy", Description = "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. The stereotypical plot line follows the boy-gets-girl, boy-loses-girl, boy gets girl back again sequence. " },
            //    new Genre { GenreID = 6, Name = "Crime", Description = "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. " },
            //    new Genre { GenreID = 7, Name = "Drama", Description = "Within film, television and radio (but not theatre), drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone," },
            //    new Genre { GenreID = 8, Name = "Sci-Fi", Description = "Science fiction is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. " },
            //    new Genre { GenreID = 9, Name = "Romance", Description = "Romance novels are emotion-driven stories that are primarily focused on the relationship between the main characters of the story." },
            //    new Genre { GenreID = 10, Name = "Fantasy", Description = "A fantasy story is about magic or supernatural forces, rather than technology, though it often is made to include elements of other genres, such as science fiction elements, for instance computers or DNA, if it happens to take place in a modern or future era. " },
            //    new Genre { GenreID = 11, Name = "Sport", Description = "The coverage of sports as a television program, on radio and other broadcasting media. It usually involves one or more sports commentators describing the events as they happen, which is called colour commentary." },
            //    new Genre { GenreID = 12, Name = "Western", Description = "Stories in the Western genre are set in the American West, between the time of the Civil war and the early nineteenth century." },
            //    new Genre { GenreID = 13, Name = "Thriller", Description = "A Thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. " },
            //    new Genre { GenreID = 14, Name = "Family", Description = "The family saga is a genre of literature which chronicles the lives and doings of a family or a number of related or interconnected families over a period of time. " }

            //};

            //modelBuilder.Entity<Genre>().HasData(genres);

            //modelBuilder.Entity<Movie>().HasData(
            //    new Movie { ID = 1, Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1/11/1989", new CultureInfo("en-US")), Director = "Rob Reiner", GenreID = genres.Single(g => g.Name == "Romantic Comedy").GenreID, Rating = 7.6, Gross = 92823600 },
            //    new Movie { ID = 2, Title = "Ghostbusters", ReleaseDate = DateTime.Parse("3/13/1984", new CultureInfo("en-US")), Director = "Ivan Reitman", GenreID = genres.Single(g => g.Name == "Comedy").GenreID, Rating = 6.5, Gross = 13612564 },
            //    new Movie { ID = 3, Title = "Ghostbusters 2", ReleaseDate = DateTime.Parse("2/23/1986", new CultureInfo("en-US")), Director = "Ivan Reitman", GenreID = genres.Single(g => g.Name == "Comedy").GenreID, Rating = 6.5, Gross = 112494738 },
            //    new Movie { ID = 4, Title = "Rio Bravo", ReleaseDate = DateTime.Parse("4/15/1959", new CultureInfo("en-US")), Director = "Howard Hawks", GenreID = genres.Single(g => g.Name == "Western").GenreID, Rating = 8.1, Gross = 5750000 },
            //    new Movie { ID = 5, Title = "The Shawshank Redemption", ReleaseDate = DateTime.Parse("10/14/1994", new CultureInfo("en-US")), Director = "Frank Darabont", GenreID = genres.Single(g => g.Name == "Drama").GenreID, Gross = 28341469, Rating = 9.3 },
            //    new Movie { ID = 6, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate = DateTime.Parse("3/24/1972", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Drama").GenreID, Gross = 134821952, Rating = 9.2 },
            //    new Movie { ID = 7, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseDate = DateTime.Parse("10/14/1994", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Thriller").GenreID, Gross = 107930000, Rating = 8.9 },
            //    new Movie { ID = 8, Title = "Schindlers List", Director = "Steven Spielberg", ReleaseDate = DateTime.Parse("2/4/1994", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Drama").GenreID, Gross = 96067179, Rating = 8.9 },
            //    new Movie { ID = 9, Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate = DateTime.Parse("7/18/2008", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Action").GenreID, Gross = 533316061, Rating = 9.0 },
            //    new Movie { ID = 10, Title = "The Lord of the Rings", Director = "Peter Jackson", ReleaseDate = DateTime.Parse("12/17/2003", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Action").GenreID, Gross = 377019252, Rating = 8.9 },
            //    new Movie { ID = 11, Title = "Star Wars", Director = "George Lucas", ReleaseDate = DateTime.Parse("5/25/1977", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Action").GenreID, Gross = 460935665, Rating = 8.7 },
            //    new Movie { ID = 12, Title = "The Matrix", Director = "The Wachowski Brothers", ReleaseDate = DateTime.Parse("3/31/1999", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Sci-Fi").GenreID, Gross = 171383253, Rating = 8.7 },
            //    new Movie { ID = 13, Title = "Forrest Gump", Director = "Robert Zemeckis", ReleaseDate = DateTime.Parse("7/6/1994", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Comedy").GenreID, Gross = 329691196, Rating = 8.8 },
            //    new Movie { ID = 14, Title = "Monty Python and the Holy Grail", Director = " Terry Gilliam & Terry Jones", ReleaseDate = DateTime.Parse("5/23/1975", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Comedy").GenreID, Gross = 1229197, Rating = 8.3 },
            //    new Movie { ID = 15, Title = "2001: A Space Odyssey", Director = "Stanley Kubrick", ReleaseDate = DateTime.Parse("4/29/1968", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Sci-Fi").GenreID, Gross = 56715371, Rating = 8.3 },
            //    new Movie { ID = 16, Title = "Back to the Future", Director = "Robert Zemeckis", ReleaseDate = DateTime.Parse("1/22/1989", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Family").GenreID, Gross = 210609762, Rating = 8.5 },
            //    new Movie { ID = 17, Title = "Monsters Inc", Director = "Pete Docter & David Silverman", ReleaseDate = DateTime.Parse("11/2/2001", new CultureInfo("en-US")), GenreID = genres.Single(g => g.Name == "Family").GenreID, Gross = 289907418, Rating = 8.1 }
            //);

        }
    }
}
