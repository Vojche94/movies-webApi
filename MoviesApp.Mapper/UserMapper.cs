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
    public class UserMapper
    {

        public static UserDto ToUserDto(UserModel model)
        {
            return new UserDto
            {
               
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                FavouriteGenre = (int)model.FavouriteGenre

            };
        }

        public static UserModel ToUserModel(UserDto model)
        {
            return new UserModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                FavouriteGenre = (Genre)model.FavouriteGenre,
                Movies = model.MovieList.Select(movie => MovieMapper.ToMovieModel(movie)).ToList()
                

            };
        }
    }
}
