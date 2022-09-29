using MoviesApp.DAL;
using MoviesApp.DAL.Repositories;
using MoviesApp.DataModels;
using MoviesApp.Exceptions;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Mapper;
using MoviesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        //private readonly MoviesStaticDbRepository _moviesRepository;
        private readonly IRepository<MoviesDto> _moviesRepository;

        public MoviesService(IRepository<MoviesDto> movieRepository)
        {
            //_moviesRepository = new MoviesStaticDbRepository();
            _moviesRepository = movieRepository;
        }

        public List<MoviesModel> GetAll()
        {
            return _moviesRepository.GetAll()
                                     .Select(movie => MovieMapper.ToMovieModel(movie))
                                     .ToList();
        }

        public List<MoviesModel> GetByGenre(int genre)
        {
            return _moviesRepository.GetByGenre(genre).Select(m=>MovieMapper.ToMovieModel(m)).ToList();
        }

       
        public MoviesModel GetById(int id)
        {
            return MovieMapper.ToMovieModel(_moviesRepository.GetById(id));

        }

        public List<MoviesModel> GetAllByUserId(int userId)
        {
            return _moviesRepository.GetAll()
                 .Where(movie => movie.UserId == userId)
                 .Select(movie => MovieMapper.ToMovieModel(movie))
                 .ToList();
        }

        public void Create(MoviesModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MoviesExceptions(model.Id, model.UserId, "Title field is required");
            }

            _moviesRepository.Add(MovieMapper.ToMovieDto(model));

        }

       
        public void DeleteByid(int id)
        {
            var movie = _moviesRepository.GetById(id);
            if (movie.Id == null)
            {
                throw new MoviesExceptions(id,null,"Id is required");
            }

            _moviesRepository.Delete(movie);
        }

        public void Update(MoviesModel model)
        {
            var movie = _moviesRepository.GetById(model.Id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            movie.UpdateMovie(model);
            _moviesRepository.Update(movie);
        }

       
    }
}
