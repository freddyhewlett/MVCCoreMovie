using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task Insert(Movie filmes)
        {
            await _context.AddAsync(filmes);
        }

        public async Task Remove(Movie filmes)
        {
            _context.Remove(filmes);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Movie>> ToList()
        {
            return await _context.Movies.Include(x => x.Genre).ToListAsync();
        }

        public async Task Update(Movie filmes)
        {
            _context.Update(filmes);
            await Task.CompletedTask;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> ListGenres()
        {
            return await _context.Genres.AsNoTracking().ToListAsync();
        }
    }
}
