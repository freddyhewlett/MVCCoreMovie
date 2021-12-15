using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class MovieViewModel
    {
        public Guid ID { get; set; }  
        
        [Required(ErrorMessage ="Campo {0} deve ser preenchido")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "{0} deve ter minimo 4 e maximo 60 caracteres")]
        [Display(Name ="Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Data de lancamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Campo {0} deve ser preenchido")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "{0} deve ter minimo 4 e maximo 60 caracteres")]
        [Display(Name = "Diretor")]
        [RegularExpression(@"^[a-zA-Z ']+$", ErrorMessage ="{0} não pode conter caracteres especiais")]
        public string Director { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Gross { get; set; }

        [Required]
        [Range(0.0, 10.0)]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public double Rating { get; set; }
        public Guid GenreID { get; set; }
        public GenreViewModel Genre { get; set; }  
        public string ImagePath { get; set; }

        [Display(Name ="Upload de imagem")]
        public IFormFile ImageUpload { get; set; }        
        

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}