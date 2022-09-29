using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataModels
{
    public class MoviesDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Year { get; set; }

        public int Genre { get; set; }
        public int UserId { get; set; }
        public virtual UserDto User { get; set; }


        public void UpdateMovie(MoviesModel model)
        {
            Title = model.Title;
            Description = model.Description;
            Year = model.Year;
            Genre = (int)model.Genre;
        }
    }



}
