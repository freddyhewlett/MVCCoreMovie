using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GenresAll();
        Task<Genre> FindById(Guid Id);
        Task<IEnumerable<Movie>> ListGenreMovie(string genre);
        Task Insert(Genre genre);
        Task Update(Genre genre);
        Task Remove(Guid id);
        Task<IEnumerable<Movie>> ListMovies();
    }
}
