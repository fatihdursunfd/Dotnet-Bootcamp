using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampMovieApp.Entity
{
    [Table("Genre")]
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
