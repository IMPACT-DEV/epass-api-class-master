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
    public class AdminRolesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public AdminRolesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/AdminRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRole>>> GetAdminRole()
        {
            return await _context.AdminRole.ToListAsync();
        }

        // GET: api/AdminRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminRole>> GetAdminRole(Guid id)
        {
            var adminRole = await _context.AdminRole.FindAsync(id);

            if (adminRole == null)
            {
                return NotFound();
            }

            return adminRole;
        }

        // PUT: api/AdminRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminRole(Guid id, AdminRole adminRole)
        {
            if (id != adminRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminRoleExists(id))
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

        // POST: api/AdminRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AdminRole>> PostAdminRole(AdminRole adminRole)
        {
            _context.AdminRole.Add(adminRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminRole", new { id = adminRole.Id }, adminRole);
        }

        // DELETE: api/AdminRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdminRole>> DeleteAdminRole(Guid id)
        {
            var adminRole = await _context.AdminRole.FindAsync(id);
            if (adminRole == null)
            {
                return NotFound();
            }

            _context.AdminRole.Remove(adminRole);
            await _context.SaveChangesAsync();

            return adminRole;
        }

        private bool AdminRoleExists(Guid id)
        {
            return _context.AdminRole.Any(e => e.Id == id);
        }
    }
}
