using AutoMapper;
using MovieApp.Domain.Model;
using MovieApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieApp.Controllers
{
    public class MovieController : ApiController
    {
        public MovieService _movieService;
        public MovieController()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile(new MovieProfile());
              });

            _movieService = new MovieService(mapperConfiguration.CreateMapper());
        }

        [HttpPost]
        public IHttpActionResult Post(MovieManagement model)
        {
            var result = _movieService.Insert(model);
            return Ok("Ok");
        }


        public IHttpActionResult Put([FromBody] MovieManagement model, [FromUri] int id)
        {
            var result = _movieService.Update(model, id);
            return Ok("Ok");
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _movieService.GetList();
            return Ok(result);
        }



    }
}