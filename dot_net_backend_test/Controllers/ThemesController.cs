using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Models.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace dot_net_backend_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly TestDBContext _context;

        public ThemesController(TestDBContext context)
        {
            _context = context;
        }

        // GET: api/Themes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theme>>> GetThemes()
        {
          if (_context.Themes == null)
          {
              return NotFound();
          }
            return await _context.Themes.ToListAsync();
        }

        // GET: api/Themes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theme>> GetTheme(int id)
        {
          if (_context.Themes == null)
          {
              return NotFound();
          }
            var theme = await _context.Themes.FindAsync(id);

            if (theme == null)
            {
                return NotFound();
            }

            return theme;
        }

        // PUT: api/Themes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public async Task<IActionResult> PutTheme(int id, Theme theme)
        {
            if (id != theme.Id)
            {
                return BadRequest();
            }

            _context.Entry(theme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeExists(id))
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

        // POST: api/Themes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public async Task<ActionResult<Theme>> PostTheme(Theme theme)
        {
          if (_context.Themes == null)
          {
              return Problem("Entity set 'TestDBContext.Themes'  is null.");
          }
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheme", new { id = theme.Id }, theme);
        }

        // DELETE: api/Themes/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public async Task<IActionResult> DeleteTheme(int id)
        {
            if (_context.Themes == null)
            {
                return NotFound();
            }
            var theme = await _context.Themes.FindAsync(id);
            if (theme == null)
            {
                return NotFound();
            }

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThemeExists(int id)
        {
            return (_context.Themes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
