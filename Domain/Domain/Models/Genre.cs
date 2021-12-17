using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Genre
    {
        public Guid GenreID { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        
    }
}
