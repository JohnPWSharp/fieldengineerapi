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
            return await _context
                .Engineers
                .Include(e => e.Appointments)
                .ToListAsync();
        }

        // GET: api/ScheduleEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179
        [HttpGet("{guid}")]
        public async Task<ActionResult<ScheduleEngineer>> GetScheduleEngineer(Guid guid)
        {
            var scheduleEngineer = await _context
                .Engineers
                .Where(e => e.guid == guid)
                .Include(e => e.Appointments)
                .FirstOrDefaultAsync();

            if (scheduleEngineer == null)
            {
                return NotFound();
            }

            return scheduleEngineer;
        }

        // GET: api/ScheduleEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179/Appointments
        [HttpGet("{guid}/Appointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetScheduleEngineerAppointments(Guid guid)
        {
            return await _context.Appointments
                .Where(a => a.EngineerGuid == guid)
                .Include(a => a.Customer)
                .Include(a => a.AppointmentStatus)
                .OrderByDescending(a => a.StartDateTime)
                .ToListAsync();
        }

        // GET: api/ScheduleEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179/Next
        [HttpGet("{guid}/Next")]
        public async Task<ActionResult<Appointment>> GetNextAppointment (Guid guid)
        {
            var nextAppointment = await _context.Appointments
                .Where(a => a.EngineerGuid == guid && a.StartDateTime > DateTime.Now)
                .Include(a => a.Customer)
                .Include(a => a.AppointmentStatus)
                .OrderBy(a => a.StartDateTime)
                .FirstOrDefaultAsync();

            if (nextAppointment == null)
            {
                return NotFound();
            }

            return nextAppointment;
        }

        // GET: api/ScheduleEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179/Today
        [HttpGet("{guid}/Today")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetTodaysAppointments(Guid guid)
        {
            var startDateTime = DateTime.Today;
            var endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

            return await _context.Appointments
                .Where(a => a.EngineerGuid == guid  && a.StartDateTime >= startDateTime && a.StartDateTime <= endDateTime)
                .Include(a => a.Customer)
                .Include(a => a.AppointmentStatus)
                .OrderBy(a => a.StartDateTime)
                .ToListAsync();
        }


        // PUT: api/ScheduleEngineer/ab9f4790-05f2-4cc3-9f01-8dfa7d848179
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutScheduleEngineer(Guid guid, ScheduleEngineer scheduleEngineer)
        {
            if (guid != scheduleEngineer.guid)
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
                if (!ScheduleEngineerExists(guid))
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
        [HttpPost]
        public async Task<ActionResult<ScheduleEngineer>> PostScheduleEngineer(ScheduleEngineer scheduleEngineer)
        {
            _context.Engineers.Add(scheduleEngineer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleEngineer", new { guid = scheduleEngineer.guid }, scheduleEngineer);
        }

        // DELETE: api/ScheduleEngineer/5
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteScheduleEngineer(Guid guid)
        {
            var scheduleEngineer = await _context.Engineers.FindAsync(guid);
            if (scheduleEngineer == null)
            {
                return NotFound();
            }

            _context.Engineers.Remove(scheduleEngineer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleEngineerExists(Guid guid)
        {
            return _context.Engineers.Any(e => e.guid == guid);
        }
    }
}
