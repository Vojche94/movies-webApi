using Microsoft.EntityFrameworkCore;
using MoviesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MoviesApp.Helpers;

namespace MoviesApp.DAL
{
    public class MoviesAppDbContext:DbContext
    {
        public MoviesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MoviesDto> Movies { get; set; }
        public DbSet<UserDto> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //space for relations with the user later on
            modelBuilder.Entity<MoviesDto>()
                .HasOne(m => m.User)
                .WithMany(u => u.MovieList)
                .HasForeignKey(m => m.UserId);



            modelBuilder.Entity<UserDto>()
                 .HasData(
                 new UserDto
                 {
                     Id = 1,
                     FirstName = "vojce",
                     LastName = "jakovleski",
                     Username = "vjakvolevski",
                     Password = StringHasher.HasherGenerator("password"),
                     FavouriteGenre = 3,



                 }) ; 


            modelBuilder.Entity<MoviesDto>()
                .HasData(
                new MoviesDto
                {
                    Id = 1,
                    Title = "Again pirates",
                    Description = "desc some of it",
                    Genre = 2,
                    Year = "2113",
                    UserId=1,
                },
                  new MoviesDto
                  {
                      Id = 2,
                      Title = "Not  pirates",
                      Description = "some desc",
                      Genre = 3,
                      Year = "2014",
                      UserId=1,
                  });




            

        }

            
    }
}
