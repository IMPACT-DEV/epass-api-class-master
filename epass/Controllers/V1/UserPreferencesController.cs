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
    public class UserPreferencesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public UserPreferencesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/UserPreferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPreference>>> GetUserPreference()
        {
            return await _context.UserPreference.ToListAsync();
        }

        // GET: api/UserPreferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPreference>> GetUserPreference(Guid id)
        {
            var userPreference = await _context.UserPreference.FindAsync(id);

            if (userPreference == null)
            {
                return NotFound();
            }

            return userPreference;
        }

        // PUT: api/UserPreferences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPreference(Guid id, UserPreference userPreference)
        {
            if (id != userPreference.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPreference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPreferenceExists(id))
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

        // POST: api/UserPreferences
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserPreference>> PostUserPreference(UserPreference userPreference)
        {
            _context.UserPreference.Add(userPreference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPreference", new { id = userPreference.Id }, userPreference);
        }

        // DELETE: api/UserPreferences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPreference>> DeleteUserPreference(Guid id)
        {
            var userPreference = await _context.UserPreference.FindAsync(id);
            if (userPreference == null)
            {
                return NotFound();
            }

            _context.UserPreference.Remove(userPreference);
            await _context.SaveChangesAsync();

            return userPreference;
        }

        private bool UserPreferenceExists(Guid id)
        {
            return _context.UserPreference.Any(e => e.Id == id);
        }
    }
}
