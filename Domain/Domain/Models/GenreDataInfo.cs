using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GenreDataInfo
    {
        [Display(Name ="Genre")]
        public string GenreName { get; set; }

        [Display(Name ="Count")]
        public int GenreCount { get; set; }

        [Display(Name ="Total Gross")]
        [DataType(DataType.Currency)]
        public decimal TotalGross { get; set; }

        [Display(Name ="Average Rating")]
        [DisplayFormat(DataFormatString ="{0:.0}")]
        public double AverageRating { get; set; }
    }
}
