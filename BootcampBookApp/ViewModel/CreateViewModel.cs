using BootcampBookApp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBookApp.ViewModel
{
    public class CreateViewModel
    {
        
        public Book book { get; set; }

        public Author author { get; set; }

        public Genre genre1 { get; set; }

        public Genre genre2 { get; set; }

        public List<SelectListItem> genres { get; set; }
        
    }
}
