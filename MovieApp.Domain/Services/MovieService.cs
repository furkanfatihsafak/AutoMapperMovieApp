using AutoMapper;
using MovieApp.Domain.Model;
using MovieApp.Entity;
using MovieApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Services
{
    public class MovieService
    {
        public GenericRepository<MovieEntity> movieRepository = new GenericRepository<MovieEntity>();
        public IMapper _mapper;
        public MovieService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool Insert(MovieManagement model)
        {
            var validation = new MovieValidator();
            var result = validation.Validate(model);
            if (!result.IsValid)
            {
                throw new Exception(result.Errors.Select(d => d.ErrorMessage).Aggregate((x, y) => x + "," + y));
            }


            var entity = _mapper.Map<MovieEntity>(model);
            entity.CreationDate = DateTime.Now;
            entity.CreationUser = "fatih";
            movieRepository.Insert(entity);
            return true;
        }
        public List<MovieList> GetList()
        {
            var list = movieRepository.List();
            return _mapper.Map<List<MovieList>>(list);
        }
        public bool Update(MovieManagement model, int id)
        {
            var validation = new MovieValidator();
            var result = validation.Validate(model);
            if (!result.IsValid)
            {
                throw new Exception(result.Errors.Select(d => d.ErrorMessage).Aggregate((x, y) => x + "," + y));
            }
            var veritabaniObj = movieRepository.GetById(id);
            var guncelVeritabaniObj = _mapper.Map(model, veritabaniObj);
            guncelVeritabaniObj.Id = id;
            movieRepository.Update(guncelVeritabaniObj);
            return true;


        }

        
    }
}
