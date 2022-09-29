using Microsoft.EntityFrameworkCore;
using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL.Repositories
{
    public class UserEntityRepository : IRepository<UserDto>
    {
        public readonly MoviesAppDbContext _context;
        public UserEntityRepository(MoviesAppDbContext context)
        {
            _context = context;
        }
        public void Add(UserDto enitty)
        {
            _context.Add(enitty);
            _context.SaveChanges();
        }

        public void Delete(UserDto entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _context.Users
                          .Include(u => u.MovieList)
                          .ToList();
            
        }

        public IEnumerable<UserDto> GetByGenre(int genre)
        {
            var user = _context.Users.Where(user => user.FavouriteGenre == genre);
            return user;
        }

        public UserDto GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }


        public void Update(UserDto entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
