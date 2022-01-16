using System;
using System.Collections.Generic;

#nullable disable

namespace BootcampBookApp.Entities
{
    public partial class Author
    {
        public Author()
        {
            AuthorBooks = new HashSet<AuthorBook>();
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
