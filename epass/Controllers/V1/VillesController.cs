using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epass.modeles;
using epass.models;
using epass.Contracts;

namespace epass.Controllers
{
    [Route(ApiRoutes.Posts.ControllersRoute)]
    [ApiController]
    public class VillesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public VillesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Villes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ville>>> GetVille()
        {
            return await _context.Ville.ToListAsync();
        }

        // GET: api/Villes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ville>> GetVille(Guid id)
        {
            var ville = await _context.Ville.FindAsync(id);

            if (ville == null)
            {
                return NotFound();
            }

            return ville;
        }

        // PUT: api/Villes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVille(Guid id, Ville ville)
        {
            if (id != ville.Id)
            {
                return BadRequest();
            }

            _context.Entry(ville).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VilleExists(id))
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

        // POST: api/Villes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ville>> PostVille(Ville ville)
        {
            _context.Ville.Add(ville);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVille", new { id = ville.Id }, ville);
        }

        // DELETE: api/Villes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ville>> DeleteVille(Guid id)
        {
            var ville = await _context.Ville.FindAsync(id);
            if (ville == null)
            {
                return NotFound();
            }

            _context.Ville.Remove(ville);
            await _context.SaveChangesAsync();

            return ville;
        }

        private bool VilleExists(Guid id)
        {
            return _context.Ville.Any(e => e.Id == id);
        }
    }
}
