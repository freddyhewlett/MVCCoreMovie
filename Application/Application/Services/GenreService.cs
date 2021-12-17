using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly INotifyService _notifyService;

        public GenreService(IGenreRepository genreRepository, INotifyService notifyService)
        {
            _genreRepository = genreRepository;
            _notifyService = notifyService;
        }

        public async Task<Genre> FindById(Guid Id)
        {
            var result = await _genreRepository.Find(x => x.GenreID == Id);

            if (result == null)
            {
                throw new Exception("Error 404"); //TODO notificar personalizado
            }

            return result;
        }

        public async Task<IEnumerable<Movie>> ListGenreMovie(string genre)
        {
            var result = await _genreRepository.FindAll(x => x.Genre.Name == genre);

            if (result == null)
            {
                throw new Exception("Error 404"); //TODO notificar personalizado
            }

            

            return result;
        }

        public async Task<IEnumerable<Genre>> GenresAll()
        {
            return await _genreRepository.ToList();
        }

        public async Task Insert(Genre genre)
        {
            if (_genreRepository.Find(x => x.Name == genre.Name).Result != null)
            {
                _notifyService.AddError("O titulo cadastrado já existe.");
                return;
            }

            await _genreRepository.Insert(genre);
            await _genreRepository.SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            var remove = await FindById(id);
            if (_notifyService.HasError()) return;

            await _genreRepository.Remove(remove);
            await _genreRepository.SaveChanges();
        }

        public async Task Update(Genre genre)
        {

            if (_notifyService.HasError()) return;

            await _genreRepository.Update(genre);
            await _genreRepository.SaveChanges();
        }

        public async Task<IEnumerable<Movie>> ListMovies()
        {
            return await _genreRepository.ListMovies();
        }
    }
}
