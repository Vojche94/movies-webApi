using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.InterfaceModels.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genre FavouriteGenre { get; set; }
        public string Token { get; set; }

        public List<MoviesModel> Movies =new List<MoviesModel>();

    }
}
