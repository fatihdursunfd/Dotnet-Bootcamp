using BootCampMovieApp.Context;
using BootCampMovieApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampMovieApp
{
    public static class DummyData
    {
        public static void Dummy(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            var genres = new List<Genre>()
                        {
                            new Genre {Name="Macera", Movies=
                                new List<Movie>(){
                                    new Movie {
                                        Title="yeni macera filmi 1",
                                        Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                                        ImageUrl="1.jpg"
                                    },
                                    new Movie {
                                        Title="yeni macera filmi 2",
                                        Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                                        ImageUrl="2.jpg"
                                    },

                                }
                            },
                            new Genre {Name="Komedi"},
                            new Genre {Name="Romantik"},
                            new Genre {Name="Savaş"},
                            new Genre {Name="Bilim Kurgu"}
                        };
            var movies = new List<Movie>()
                        {
                            new Movie {
                                Title="Jiu Jitsu",
                                Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                                ImageUrl="1.jpg",
                                Genres = new List<Genre>() {genres[0], new Genre(){Name="Yeni Tür"}, genres[1] }
                            },
                            new Movie {
                                Title="Fatman",
                                Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                                ImageUrl="2.jpg",
                                Genres = new List<Genre>() {genres[0],genres[2] }
                            },
                            new Movie {
                                Title="The Dalton Gang",
                                Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                                ImageUrl="3.jpg",
                                Genres = new List<Genre>() {genres[1], genres[3] }
                            },
                                new Movie {
                                Title="Tenet",
                                Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                                ImageUrl="4.jpg",
                                Genres = new List<Genre>() {genres[0], genres[1] }
                            },
                            new Movie {
                                Title="The Craft: Legacy",
                                Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                                ImageUrl="5.jpg",
                                Genres = new List<Genre>() {genres[2], genres[4] }
                            },
                            new Movie {
                                Title="Hard Kill",
                                Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                                ImageUrl="6.jpg",
                                Genres = new List<Genre>() {genres[1], genres[2] }
                            }
                        };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context.genre.Count() == 0)
                {
                    context.genre.AddRange(genres);
                }
                if (context.movie.Count() == 0)
                {
                    context.movie.AddRange(movies);
                }
                context.SaveChanges();


            }

        }
    }
}
