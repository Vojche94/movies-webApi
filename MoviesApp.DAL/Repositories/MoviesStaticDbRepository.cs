using MoviesApp.DataModels;
using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL.Repositories
{
    public class MoviesStaticDbRepository : IRepository<MoviesDto>
    {
        public void  Add(MoviesDto entity)
        {
            MoviesStaticDB.Movies.Add(entity);

        }

        public void Delete(MoviesDto entity)
        {
            MoviesStaticDB.Movies.Remove(entity);
        }

        public IEnumerable<MoviesDto> GetAll()
        {
            return MoviesStaticDB.Movies;
        }

        public IEnumerable<MoviesDto> GetByGenre(int genre)
        {
            var result = MoviesStaticDB.Movies.FindAll(movie => movie.Genre == genre) ;
            return result;
        }

        public MoviesDto GetById(int id)
        {
            var result = MoviesStaticDB.Movies.FirstOrDefault(movie => movie.Id == id);
            return result;
        }


        public void Update(MoviesDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
