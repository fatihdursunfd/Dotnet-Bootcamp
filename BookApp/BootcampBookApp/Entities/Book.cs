using System;
using System.Collections.Generic;

#nullable disable

namespace BootcampBookApp.Entities
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual List<AuthorBook> AuthorBooks { get; set; }
    }
}
