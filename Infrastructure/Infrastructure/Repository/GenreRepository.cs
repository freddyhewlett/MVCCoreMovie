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
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _context;

        public GenreRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> Find(Expression<Func<Genre, bool>> predicate)
        {
            return await _context.Genres.Include(x => x.Movies).Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> FindAll(Expression<Func<Movie, bool>> predicate)
        {
            return await _context.Movies.Include(x => x.Genre).Where(predicate).ToListAsync();
        }

        public async Task Insert(Genre genre)
        {
            await _context.AddAsync(genre);
        }

        public async Task Remove(Genre genre)
        {
            _context.Remove(genre);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Genre>> ToList()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task Update(Genre genre)
        {
            _context.Update(genre);
            await Task.CompletedTask;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> ListMovies()
        {
            return await _context.Movies.AsNoTracking().ToListAsync();
        }

        
    }
}
