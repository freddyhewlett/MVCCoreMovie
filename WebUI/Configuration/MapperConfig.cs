using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MovieViewModel, Domain.Models.Movie>().ReverseMap();
            CreateMap<GenreViewModel, Domain.Models.Genre>().ReverseMap();
            CreateMap<LogViewModel, Domain.Models.Log>().ReverseMap();
            CreateMap<ErrorViewModel, Domain.Models.Error>().ReverseMap();
        }
    }
}
