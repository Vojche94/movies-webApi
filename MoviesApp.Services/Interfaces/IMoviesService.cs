using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Interfaces
{
    public interface IMoviesService
    {
        List<MoviesModel> GetAll();
        List<MoviesModel> GetAllByUserId(int userId);
        MoviesModel GetById(int id);
        List<MoviesModel> GetByGenre(int genre);
        void Create(MoviesModel model);
        void DeleteByid(int id);
        void Update(MoviesModel model);
        

    }
}
