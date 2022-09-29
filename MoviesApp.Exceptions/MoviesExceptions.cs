using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Exceptions
{
    public class MoviesExceptions:Exception
    {
        public int? MovieId { get; set; }
        public int? UserId { get; set; }

        public MoviesExceptions() : base("there was a problem with the movie ") { }


        public MoviesExceptions(int? movieId, int? userId)
            : base("There was a problem with the movie")
        {
            MovieId = movieId;
            UserId = userId;
        }

        public MoviesExceptions(int? movieId,int? userId,string message)
            : base(message)
        {
            MovieId = movieId;
            UserId = userId;
        }
        
    }
}
