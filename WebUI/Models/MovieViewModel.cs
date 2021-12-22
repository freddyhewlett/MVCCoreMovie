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
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Gross { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "O {0} deve conter apenas numeros positivos e apenas uma casa decimal")]
        [Range(typeof(double), "0", "10", ConvertValueInInvariantCulture = true, ErrorMessage = "O {0} deve ser entre 0 e 10.")]
        public double Rating { get; set; }

        [Display(Name ="Genero")]
        public Guid GenreID { get; set; }
        public GenreViewModel Genre { get; set; } 
        
        [Display(Name ="Picture")]
        public string ImagePath { get; set; }        
        public IFormFile ImageUpload { get; set; }        
        

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}