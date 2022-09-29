using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByGenre(int genre);
        T GetById(int id);
        void  Add(T enitty);
        void Delete(T entity);
        void Update(T entity);


    }
}
