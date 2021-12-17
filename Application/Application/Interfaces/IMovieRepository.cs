using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> ToList();
        Task<Movie> Find(Expression<Func<Movie, bool>> predicate);
        Task Insert(Movie movie);
        Task Update(Movie movie);
        Task Remove(Movie movie);
        IQueryable<string> MovieFilter(string term);
        IQueryable<Movie> SearchString(string search, Guid? selectedGenre);

        Task<int> SaveChanges();
        Task<IEnumerable<Genre>> ListGenres();
    }
}
