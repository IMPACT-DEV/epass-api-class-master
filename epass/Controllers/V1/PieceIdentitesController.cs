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
    public class PieceIdentitesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public PieceIdentitesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/PieceIdentites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceIdentite>>> GetPieceIdentite()
        {
            return await _context.PieceIdentite.ToListAsync();
        }

        // GET: api/PieceIdentites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PieceIdentite>> GetPieceIdentite(Guid id)
        {
            var pieceIdentite = await _context.PieceIdentite.FindAsync(id);

            if (pieceIdentite == null)
            {
                return NotFound();
            }

            return pieceIdentite;
        }

        // PUT: api/PieceIdentites/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPieceIdentite(Guid id, PieceIdentite pieceIdentite)
        {
            if (id != pieceIdentite.Id)
            {
                return BadRequest();
            }

            _context.Entry(pieceIdentite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceIdentiteExists(id))
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

        // POST: api/PieceIdentites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PieceIdentite>> PostPieceIdentite(PieceIdentite pieceIdentite)
        {
            _context.PieceIdentite.Add(pieceIdentite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPieceIdentite", new { id = pieceIdentite.Id }, pieceIdentite);
        }

        // DELETE: api/PieceIdentites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PieceIdentite>> DeletePieceIdentite(Guid id)
        {
            var pieceIdentite = await _context.PieceIdentite.FindAsync(id);
            if (pieceIdentite == null)
            {
                return NotFound();
            }

            _context.PieceIdentite.Remove(pieceIdentite);
            await _context.SaveChangesAsync();

            return pieceIdentite;
        }

        private bool PieceIdentiteExists(Guid id)
        {
            return _context.PieceIdentite.Any(e => e.Id == id);
        }
    }
}
