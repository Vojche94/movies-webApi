using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Exceptions
{
    public class UserExceptions:Exception
    {
        public int? UserId { get; set; }
        public string Name { get; set; }

        public UserExceptions() : base("There was a problem with the user") { }

        public UserExceptions(int?userId,string name)
            :base("There was a proble with the user")
        {
            UserId = userId;
            Name = name;

        }

        public UserExceptions(int? userId,string name,string message)
            :base(message)
        {
            UserId = userId;
            Name = name;
        }
    }
}
