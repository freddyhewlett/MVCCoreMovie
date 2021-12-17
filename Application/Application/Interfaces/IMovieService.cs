﻿using Domain.Models;
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
        Task Insert(Movie movie);
        Task Update(Movie movie);
        Task Remove(Guid id);
        Task<IEnumerable<Genre>> ListGenres();
        IQueryable<string> MovieFilter(string term);
        IQueryable<Movie> SearchString(string search, Guid? selectedGenre);
    }
}
