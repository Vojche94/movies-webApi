using MoviesApp.InterfaceModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.InterfaceModels.Models
{
    public class MoviesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }

        public Genre Genre { get; set; }
        public int UserId { get; set; }

  
    }

    
}
