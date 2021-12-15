using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> MoviesAll();
        Task<Movie> FindById(Guid Id);
        Task Insert(Movie filmes);
        Task Update(Movie filmes);
        Task Remove(Movie filmes);
        Task<IEnumerable<Genre>> ListGenres();
    }
}
