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

        public IQueryable<string> MovieFilter(string term)
        {
            var movies = from movie in _context.Movies
                         where (movie.Title.ToLower().Contains(term))
                         select movie.Title;
            return movies;
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
            var movie = await _context.Movies.AsNoTracking().ToListAsync();
            var movieScope = movie.Find(x => x.Id == id);
            //var movie = await _context.Movies.FindAsync(id);
            var path = movieScope.ImagePath;
            return path;
        }
    }
}
