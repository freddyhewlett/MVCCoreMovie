﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class MovieViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-Z][\s''-']{1,100}$"] //TODO teste
        public string Director { get; set; }

        // [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Gross { get; set; }

        [Range(0.0, 10.0)]
        public double Rating { get; set; }
        public int GenreID { get; set; }
        public virtual GenreViewModel Genre { get; set; }

        [Display(Name = "Upload Image")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        [Display(Name = "Image link")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}