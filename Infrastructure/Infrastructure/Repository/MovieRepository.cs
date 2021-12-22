using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Find(Expression<Func<Movie, bool>> predicate)
        {
            return await _context.Movies.Include(x => x.Genre).Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> SortFilter(string sortOrder)
        {
            var movies = from m in _context.Movies select m;
            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseDate);
                    break;
                case "Gross":
                    movies = movies.OrderBy(m => m.Gross);
                    break;
                case "gross_desc":
                    movies = movies.OrderByDescending(m => m.Gross);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating);
                    break;
                case "rate_desc":
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }
            return await movies.AsNoTracking().ToListAsync();
        }

        public async Task Insert(Movie movie)
        {
            await _context.AddAsync(movie);
        }

        public async Task Remove(Movie movie)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", movie.ImagePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            _context.Remove(movie);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Movie>> ToList()
        {
            return await _context.Movies.Include(x => x.Genre).ToListAsync();
        }

        public async Task Update(Movie movie)
        {
            
            _context.Update(movie);
            await Task.CompletedTask;
        }

        public IQueryable<Movie> SearchString(string search, Guid? selectedGenre)
        {
            var genreID = selectedGenre.GetValueOrDefault();
            var movies = _context.Movies.Where(c => !selectedGenre.HasValue || c.GenreID == genreID);
            if (!String.IsNullOrEmpty(search))
            {
                movies = movies.Where(s => s.Title.Contains(search) || s.Director.Contains(search));
            }
            return movies;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> ListGenres()
        {
            return await _context.Genres.AsNoTracking().ToListAsync();
        }

        public async Task<string> FindImagePath(Guid id)
        {
            var movieList = await _context.Movies.AsNoTracking().ToListAsync();
            var movie = movieList.Find(x => x.Id == id);
            var path = movie.ImagePath;
            return path;
        }
    }
}
