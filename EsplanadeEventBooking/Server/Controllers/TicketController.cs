using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsplanadeEventBooking.Server.Data;
using EsplanadeEventBooking.Shared.Domain;
using EsplanadeEventBooking.Server.IRepository;

namespace EsplanadeEventBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public TicketsController(ApplicationDbContext context)
        public TicketsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tickets
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        public async Task<IActionResult> GetTickets()
        {
            //return await _context.Tickets.ToListAsync();
            var tickets = await _unitOfWork.Tickets.GetAll(includes: q => q.Include(x => x.Bookevent).Include(x => x.Euser));
            return Ok(tickets);
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Ticket>> GetTicket(int id)
        public async Task<IActionResult> GetTicket(int id)
        {
            //var ticket = await _context.Tickets.FindAsync(id);
            var ticket = await _unitOfWork.Tickets.Get(q => q.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            //_context.Entry(ticket).State = EntityState.Modified;
            _unitOfWork.Tickets.Update(ticket);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);    
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TicketExists(id))
                if (!await TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            //_context.Tickets.Add(ticket);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Tickets.Insert(ticket);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            //var ticket = await _context.Tickets.FindAsync(id);
            var ticket = await _unitOfWork.Tickets.Get(q => q.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            //_context.Tickets.Remove(ticket);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Tickets.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TicketExists(int id)
        {
            //return _context.Tickets.Any(e => e.Id == id);
            var ticket = await _unitOfWork.Tickets.Get(q => q.Id == id);
            return ticket != null;
        }
    }
}
