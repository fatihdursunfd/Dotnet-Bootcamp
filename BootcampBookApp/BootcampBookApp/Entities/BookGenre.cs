using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BootcampBookApp.Entities
{
    public partial class BookGenre
    {

        public int BooksBookId { get; set; }
        public int GenresGenreId { get; set; }

        public virtual Book BooksBook { get; set; }
        public  Genre GenresGenre { get; set; }
    }
}
