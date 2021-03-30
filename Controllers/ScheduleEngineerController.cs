using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FieldEngineerApi.Models;

namespace FieldEngineerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleEngineerController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public ScheduleEngineerController(ScheduleContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleEngineer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleEngineer>>> GetEngineers()
        {
            return await _context.Engineers.ToListAsync();
        }

        // GET: api/ScheduleEngineer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleEngineer>> GetScheduleEngineer(string id)
        {
            var scheduleEngineer = await _context.Engineers.FindAsync(id);

            if (scheduleEngineer == null)
            {
                return NotFound();
            }

            return scheduleEngineer;
        }

        // GET: api/ScheduleEngineer/5/Appointments 
        [HttpGet("{id}/Appointments")] 
        public async Task<ActionResult<IEnumerable<Appointment>>> GetScheduleEngineerAppointments(string id) 
        { 
            return await _context.Appointments  
                .Where(a => a.EngineerId == id) 
                .OrderByDescending(a => a.StartDateTime) 
                .ToListAsync(); 
        } 

        // GET: api/ScheduleEngineer/5/Next 
        [HttpGet("{id}/Next")] 
        public async Task<ActionResult<Appointment>> GetNextAppointment (string id) 
        { 
            var nextAppointment = await _context.Appointments 
                .Where(a => a.EngineerId == id && a.StartDateTime > DateTime.Now) 
                .OrderBy(a => a.StartDateTime) 
                .FirstOrDefaultAsync(); 
    
            if (nextAppointment == null) 
            { 
                return NotFound(); 
            } 

            return nextAppointment; 

        }

        // GET: api/ScheduleEngineer/5/Today 
        [HttpGet("{id}/Today")] 
        public async Task<ActionResult<IEnumerable<Appointment>>> GetTodaysAppointments(string id) 
        { 
            var startDateTime = DateTime.Today; 
            var endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); 

            return await _context.Appointments 
                .Where(a => a.EngineerId == id  &&  
                    a.StartDateTime >= startDateTime && 
                    a.StartDateTime <= endDateTime) 
            .OrderBy(a => a.StartDateTime) 
            .ToListAsync(); 
        }

        // PUT: api/ScheduleEngineer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleEngineer(string id, ScheduleEngineer scheduleEngineer)
        {
            if (id != scheduleEngineer.Id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleEngineer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleEngineerExists(id))
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

        // POST: api/ScheduleEngineer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleEngineer>> PostScheduleEngineer(ScheduleEngineer scheduleEngineer)
        {
            _context.Engineers.Add(scheduleEngineer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleEngineer", new { Id = scheduleEngineer.Id }, scheduleEngineer);
        }

        // DELETE: api/ScheduleEngineer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleEngineer(string id)
        {
            var scheduleEngineer = await _context.Engineers.FindAsync(id);
            if (scheduleEngineer == null)
            {
                return NotFound();
            }

            _context.Engineers.Remove(scheduleEngineer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleEngineerExists(string id)
        {
            return _context.Engineers.Any(e => e.Id == id);
        }
    }
}
