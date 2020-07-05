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
    public class InfoComptesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public InfoComptesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/InfoComptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoCompte>>> GetInfoCompte()
        {
            return await _context.InfoCompte.ToListAsync();
        }

        // GET: api/InfoComptes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoCompte>> GetInfoCompte(Guid id)
        {
            var infoCompte = await _context.InfoCompte.FindAsync(id);

            if (infoCompte == null)
            {
                return NotFound();
            }

            return infoCompte;
        }

        // PUT: api/InfoComptes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoCompte(Guid id, InfoCompte infoCompte)
        {
            if (id != infoCompte.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoCompte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoCompteExists(id))
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

        // POST: api/InfoComptes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InfoCompte>> PostInfoCompte(InfoCompte infoCompte)
        {
            _context.InfoCompte.Add(infoCompte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoCompte", new { id = infoCompte.Id }, infoCompte);
        }

        // DELETE: api/InfoComptes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InfoCompte>> DeleteInfoCompte(Guid id)
        {
            var infoCompte = await _context.InfoCompte.FindAsync(id);
            if (infoCompte == null)
            {
                return NotFound();
            }

            _context.InfoCompte.Remove(infoCompte);
            await _context.SaveChangesAsync();

            return infoCompte;
        }

        private bool InfoCompteExists(Guid id)
        {
            return _context.InfoCompte.Any(e => e.Id == id);
        }
    }
}
