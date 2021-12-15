using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Movie : Entity
    {      
        public string Title { get; set; }        
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public decimal Gross { get; set; }
        public double Rating { get; set; }
        public Guid GenreID { get; set; }
        public Genre Genre { get; set; }
        public string ImagePath { get; set; }


        public Movie() { }

        public Movie(Guid id, string title, string diretcor, DateTime release, decimal gross, double rating)
        {
            GenreID = id;
            Title = title;
            Director = diretcor;
            ReleaseDate = release;
            Gross = gross;
            Rating = rating;
        }

        public void SetImagePath(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
