using AutoMapper;
using FluentValidation;
using MovieApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Model
{
    public class MovieManagement
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MovieList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MovieProfile : Profile
    {
        public MovieProfile()
        { 
            CreateMap<MovieEntity, MovieList>();
            CreateMap<MovieEntity, MovieManagement>();
            CreateMap<MovieManagement, MovieEntity>();
        }
    }

    public class MovieValidator : AbstractValidator<MovieManagement>
    {
        public MovieValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
