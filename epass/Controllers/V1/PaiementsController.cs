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
    public class PaiementsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public PaiementsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Paiements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paiement>>> GetPaiement()
        {
            return await _context.Paiement.ToListAsync();
        }

        // GET: api/Paiements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paiement>> GetPaiement(Guid id)
        {
            var paiement = await _context.Paiement.FindAsync(id);

            if (paiement == null)
            {
                return NotFound();
            }

            return paiement;
        }

        // PUT: api/Paiements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaiement(Guid id, Paiement paiement)
        {
            if (id != paiement.Id)
            {
                return BadRequest();
            }

            _context.Entry(paiement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiementExists(id))
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

        // POST: api/Paiements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paiement>> PostPaiement(Paiement paiement)
        {
            _context.Paiement.Add(paiement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaiement", new { id = paiement.Id }, paiement);
        }

        // DELETE: api/Paiements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paiement>> DeletePaiement(Guid id)
        {
            var paiement = await _context.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }

            _context.Paiement.Remove(paiement);
            await _context.SaveChangesAsync();

            return paiement;
        }

        private bool PaiementExists(Guid id)
        {
            return _context.Paiement.Any(e => e.Id == id);
        }
    }
}
