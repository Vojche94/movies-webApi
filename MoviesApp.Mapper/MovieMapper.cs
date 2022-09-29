using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mapper
{
    public class MovieMapper
    {
        public static MoviesDto ToMovieDto(MoviesModel model)
        {
            return new MoviesDto
            {
                
                Title = model.Title,
                Description = model.Description,
                Year = model.Year,
                Genre = (int)model.Genre,
                UserId=model.UserId


            };
        }

        public static MoviesModel ToMovieModel(MoviesDto model)
        {
            return new MoviesModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Year = model.Year,
                Genre = (Genre)model.Genre,
                UserId=model.UserId

            };
        }
    }
}
