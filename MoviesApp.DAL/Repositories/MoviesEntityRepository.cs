using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL.Repositories
{
    public class MoviesEntityRepository : IRepository<MoviesDto>
    {
        private readonly MoviesAppDbContext _context;
        public MoviesEntityRepository(MoviesAppDbContext context)
        {
            _context = context;
        }

        public void Add(MoviesDto entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(MoviesDto entity)
        {
            _context.Movies.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<MoviesDto> GetAll()
        {
            return _context.Movies;
        }

        public IEnumerable<MoviesDto> GetByGenre(int genre)
        {
            var movie = _context.Movies.Where(m => m.Genre == genre);
            return movie;
        }

        public MoviesDto GetById(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return movie;
        }

        public MoviesDto GetById(int id, int userId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id && m.UserId == userId);
            return movie;
        }



        public void Update(MoviesDto entity)
        {
            //

            _context.Movies.Update(entity);
            _context.SaveChanges();
            
        }
    }
}
