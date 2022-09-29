using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DAL;
using MoviesApp.DAL.Repositories;
using MoviesApp.DataModels;
using MoviesApp.Services.Implementations;
using MoviesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Utilites
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<MoviesAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });



            services.AddTransient<IMoviesService, MoviesService>();
            services.AddTransient<IUserService,UserService > ();

            services.AddTransient<IRepository<MoviesDto>,MoviesEntityRepository>();
            services.AddTransient<IRepository<UserDto>, UserEntityRepository>();

            return services;
        }
    }
}
