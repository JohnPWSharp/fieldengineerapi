using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FieldEngineerApi.Models;

namespace FieldEngineerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseEngineerController : ControllerBase
    {
        private readonly KnowledgeBaseContext _context;

        public KnowledgeBaseEngineerController(KnowledgeBaseContext context)
        {
            _context = context;
        }

        // GET: api/KnowledgeBaseEngineer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnowledgeBaseEngineer>>> GetEngineers()
        {
            return await _context.Engineers.ToListAsync();
        }

        // GET: api/KnowledgeBaseEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179
        [HttpGet("{guid}")]
        public async Task<ActionResult<KnowledgeBaseEngineer>> GetKnowledgeBaseEngineer(Guid guid)
        {
            var knowledgeBaseEngineer = await _context.Engineers.FindAsync(guid);

            if (knowledgeBaseEngineer == null)
            {
                return NotFound();
            }

            return knowledgeBaseEngineer;
        }

        // GET: api/KnowledgeBaseEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179/Tips
        [HttpGet("{guid}/Tips")]
        public async Task<ActionResult<IEnumerable<KnowledgeBaseTip>>> GetTipsForEngineer(Guid guid)
        {
            return await _context.Tips.Where(t => t.KnowledgeBaseEngineerGuid == guid).ToListAsync();
        }

        // PUT: api/KnowledgeBaseEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutKnowledgeBaseEngineer(Guid guid, KnowledgeBaseEngineer knowledgeBaseEngineer)
        {
            if (guid != knowledgeBaseEngineer.guid)
            {
                return BadRequest();
            }

            _context.Entry(knowledgeBaseEngineer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeBaseEngineerExists(guid))
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

        // POST: api/KnowledgeBaseEngineer
        [HttpPost]
        public async Task<ActionResult<KnowledgeBaseEngineer>> PostKnowledgeBaseEngineer(KnowledgeBaseEngineer knowledgeBaseEngineer)
        {
            _context.Engineers.Add(knowledgeBaseEngineer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnowledgeBaseEngineer", new { guid = knowledgeBaseEngineer.guid }, knowledgeBaseEngineer);
        }

        // DELETE: api/KnowledgeBaseEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteKnowledgeBaseEngineer(Guid guid)
        {
            var knowledgeBaseEngineer = await _context.Engineers.FindAsync(guid);
            if (knowledgeBaseEngineer == null)
            {
                return NotFound();
            }

            _context.Engineers.Remove(knowledgeBaseEngineer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KnowledgeBaseEngineerExists(Guid guid)
        {
            return _context.Engineers.Any(e => e.guid == guid);
        }
    }
}
