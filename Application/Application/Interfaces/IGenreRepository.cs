using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> ToList();
        Task<Genre> Find(Expression<Func<Genre, bool>> predicate);
        Task<IEnumerable<Movie>> FindAll(Expression<Func<Movie, bool>> predicate);
        Task Insert(Genre genre);
        Task Update(Genre genre);
        Task Remove(Genre genre);
        


        Task<int> SaveChanges();
        Task<IEnumerable<Movie>> ListMovies();
    }
}
