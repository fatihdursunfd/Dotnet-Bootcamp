using BootcampBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBookApp.ViewModel
{
    public class ListViewModel
    {
        
        public Book book { get; set; }

        public Author authors { get; set; }

        public Genre genres { get; set; }
        

    }
}
