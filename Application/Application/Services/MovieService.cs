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
            var result = await _movieRepository.Find(x => x.Id == Id);

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

        public async Task Insert(Movie movie)
        {
            if (_movieRepository.Find(x => x.Title == movie.Title).Result != null)
            {
                _notifyService.AddError("O titulo cadastrado já existe.");
                return;
            }

            await _movieRepository.Insert(movie);
            await _movieRepository.SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            var remove = await FindById(id);
            if (_notifyService.HasError()) return;

            await _movieRepository.Remove(remove);
            await _movieRepository.SaveChanges();
        }

        public async Task Update(Movie movie)
        {
            
            if (_notifyService.HasError()) return;

            await _movieRepository.Update(movie);
            await _movieRepository.SaveChanges();
        }

        public async Task<IEnumerable<Genre>> ListGenres()
        {
            return await _movieRepository.ListGenres();
        }

        public IQueryable<string> MovieFilter(string term)
        {
            var movies = _movieRepository.MovieFilter(term);

            return movies;
        }

        public IQueryable<Movie> SearchString(string search, Guid? selectedGenre)
        {
            var movies = _movieRepository.SearchString(search, selectedGenre);

            return movies;
        }

        public async Task<string> FindImagePath(Guid id)
        {
            return await _movieRepository.FindImagePath(id);
        }
    }
}
