using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApp.InterfaceModels.Enums;

namespace MoviesApp.DAL
{
    public static class MoviesStaticDB
    {
        public static List<MoviesDto> Movies = new List<MoviesDto>
        {
            new MoviesDto
            {
                Id=0,
                Title="Pirates of the Carribean",
                Description="Great Movie",
                Year="2004",
                Genre=2
            },

            new MoviesDto
            {
                Id=1,
                Title="Pirates of the Carribean 2",
                Description="Even Greater Movie",
                Year="2008",
                Genre=1
                
            }
        };

    }
}
