using BootcampBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBookApp.ViewModel
{
    public class HomeViewModel
    {
        public List<Book> books { get; set; }

        public List<Genre> genres { get; set; }
    }
}
