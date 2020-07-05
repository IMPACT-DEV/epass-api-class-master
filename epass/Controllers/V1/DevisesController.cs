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
    public class DevisesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public DevisesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Devises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devise>>> GetDevise()
        {
            return await _context.Devise.ToListAsync();
        }

        // GET: api/Devises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devise>> GetDevise(Guid id)
        {
            var devise = await _context.Devise.FindAsync(id);

            if (devise == null)
            {
                return NotFound();
            }

            return devise;
        }

        // PUT: api/Devises/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevise(Guid id, Devise devise)
        {
            if (id != devise.Id)
            {
                return BadRequest();
            }

            _context.Entry(devise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviseExists(id))
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

        // POST: api/Devises
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Devise>> PostDevise(Devise devise)
        {
            _context.Devise.Add(devise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevise", new { id = devise.Id }, devise);
        }

        // DELETE: api/Devises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Devise>> DeleteDevise(Guid id)
        {
            var devise = await _context.Devise.FindAsync(id);
            if (devise == null)
            {
                return NotFound();
            }

            _context.Devise.Remove(devise);
            await _context.SaveChangesAsync();

            return devise;
        }

        private bool DeviseExists(Guid id)
        {
            return _context.Devise.Any(e => e.Id == id);
        }
    }
}
