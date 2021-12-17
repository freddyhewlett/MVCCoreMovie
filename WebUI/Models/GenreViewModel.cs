using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class GenreViewModel
    {
        public Guid GenreID { get; set; }        
        public string Name { get; set; }        
        public string Description { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }

        public GenreViewModel(string name, string description, IEnumerable<MovieViewModel> movies)
        {
            Name = name;
            Description = description;
            Movies = movies;
        }
    }
}
