using BootcampApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : Controller
    {
        private readonly TutorialDbContext _context;

        public TutorialController(TutorialDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tutorials = _context.Tutorials.ToList();
            return Ok(tutorials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tutorial>> GetTutorial(int id)

        {
            var tutorial = await _context.Tutorials.FindAsync(id);
            if(tutorial == null)
            {
                return NotFound();
            }
            return Ok(tutorial);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tutorial>> UpdateTutorial(int id , Tutorial tutorial)
        {
            if (id != tutorial.Id)
                return BadRequest();
            _context.Entry(tutorial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool TutorialExists(int id)
        {
            return _context.Tutorials.Any(e => e.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult<Tutorial>> PostTutorial(Tutorial tutorial)
        {
            _context.Tutorials.Add(tutorial);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTutorial", new { id = tutorial.Id }, tutorial);
        }

        
        [HttpDelete("{id}")]

        public async Task<ActionResult<Tutorial>> DeleteTutorial(int id)
        {
            var tutorial = await _context.Tutorials.FindAsync(id);
            if (tutorial == null)
            {
                return NotFound();
            }
            _context.Tutorials.Remove(tutorial);
            await _context.SaveChangesAsync();

            return tutorial;
        }

        [HttpGet]
        [Route("SearchTutorial/{title}")]

        public IActionResult SearchTutorials(string title)
        {
            IQueryable<Tutorial> query;
            query = _context.Tutorials.Where(x => x.Title.Contains(title));
            var tutorialResponse = query.Select(x => new Tutorial()
            {
                Id = x.Id ,
                Title = x.Title,
                Description = x.Description
            });

            return Ok(query);
        }
    }
}
