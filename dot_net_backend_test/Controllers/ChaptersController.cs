﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Models.DataModels;
using dot_net_backend_test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace dot_net_backend_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly TestDBContext _context;
        private readonly IChapterService _chapterService;

        public ChaptersController(TestDBContext context, IChapterService chapterService)
        {
            _context = context;
            _chapterService = chapterService;
        }

        // GET: api/Chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters()
        {
          if (_context.Chapters == null)
          {
              return NotFound();
          }
            return await _context.Chapters.ToListAsync();
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
          if (_context.Chapters == null)
          {
              return NotFound();
          }
            var chapter = await _context.Chapters.FindAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return chapter;
        }

        // GET: api/Chapters/Courses/1
        [HttpGet("GetChaptersWithCourseId/{courseId}")]
        public IEnumerable<Chapter> GetChaptersWithCourseId(int courseId)
        {
            return _chapterService.GetChaptersWhereCourseId(courseId);
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public async Task<IActionResult> PutChapter(int id, Chapter chapter)
        {
            if (id != chapter.Id)
            {
                return BadRequest();
            }

            _context.Entry(chapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public async Task<ActionResult<Chapter>> PostChapter(Chapter chapter)
        {
          if (_context.Chapters == null)
          {
              return Problem("Entity set 'TestDBContext.Chapters'  is null.");
          }
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public async Task<IActionResult> DeleteChapter(int id)
        {
            if (_context.Chapters == null)
            {
                return NotFound();
            }
            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChapterExists(int id)
        {
            return (_context.Chapters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
