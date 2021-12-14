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

        public async Task<Movie> FindById(int Id)
        {
            var result = await _movieRepository.Find(x => x.ID == Id);

            //Validar se é nulo, caso seja retornar erro

            return result;
        }

        public async Task<IEnumerable<Movie>> FilmesAll()
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

        public async Task<IEnumerable<Genre>> ListGeneros()
        {
            return await _movieRepository.ListGeneros();
        }
    }
}
