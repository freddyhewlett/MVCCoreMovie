using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly INotifyService _notifyService;

        public MovieService(IMovieRepository movieRepository, INotifyService notifyService)
        {
            _movieRepository = movieRepository;
            _notifyService = notifyService;
        }

        public async Task<Movie> FindById(Guid Id)
        {
            var result = await _movieRepository.Find(x => x.GenreID == Id);

            if (result == null)
            {
                throw new Exception("Error 404"); //TODO notificar parsonalizado
            }

            return result;
        }

        public async Task<IEnumerable<Movie>> MoviesAll()
        {
            return await _movieRepository.ToList();
        }

        public async Task Insert(Movie filmes)
        {
            if (_movieRepository.Find(x => x.Title == filmes.Title).Result != null)
            {
                _notifyService.AddError("O titulo cadastrado já existe.");
                return;
            }

            await _movieRepository.Insert(filmes);
            await _movieRepository.SaveChanges();
        }

        public async Task Remove(Movie filmes)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Movie filmes)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>> ListGenres()
        {
            return await _movieRepository.ListGenres();
        }
    }
}
