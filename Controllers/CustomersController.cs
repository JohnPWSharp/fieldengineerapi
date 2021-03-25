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
    public class CustomersController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public CustomersController(ScheduleContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context
                .Customers
                .Include(c => c.Appointments)
                .ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context
                .Customers
                .Where(c => c.Id == id)
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        //GET: api/Customers/5/Appointments
        [HttpGet("{id}/Appointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments(long id)
        {
            return await _context.Appointments
                .Where(a => a.CustomerId == id)
                .OrderByDescending(a => a.StartDateTime)
                .ToListAsync();
        }

        //GET: api/Customers/5/Notes
        [HttpGet("{id}/Notes")]
        public async Task<ActionResult<IEnumerable<object>>> GetNotes(long id)
        {
            return await _context.Appointments
                .Where(a => a.CustomerId == id)
                .OrderByDescending(a => a.StartDateTime)
                .Select(a => new {a.StartDateTime, a.ProblemDetails, a.Notes})
                .ToListAsync();
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
