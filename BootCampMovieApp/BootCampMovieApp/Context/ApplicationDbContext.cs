using BootCampMovieApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BootCampMovieApp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
        {

        }

        public virtual DbSet<Genre> genre { get; set; }

        public virtual DbSet<Movie> movie { get; set; }

        


    }
}
