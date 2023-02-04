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
    public class EuserController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public EusersController(ApplicationDbContext context)
        public EuserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Eusers
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Euser>>> GetEusers()
        public async Task<IActionResult> GetEusers()
        {
            //return await _context.Eusers.ToListAsync();
            var eusers = await _unitOfWork.Eusers.GetAll();
            return Ok(eusers);
        }

        // GET: api/Eusers/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Euser>> GetEuser(int id)
        public async Task<IActionResult> GetEuser(int id)
        {
            //var euser = await _context.Eusers.FindAsync(id);
            var euser = await _unitOfWork.Eusers.Get(q => q.Id == id);

            if (euser == null)
            {
                return NotFound();
            }

            return Ok(euser);
        }

        // PUT: api/Eusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuser(int id, Euser euser)
        {
            if (id != euser.Id)
            {
                return BadRequest();
            }

            //_context.Entry(euser).State = EntityState.Modified;
            _unitOfWork.Eusers.Update(euser);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);    
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!EuserExists(id))
                if (!await EuserExists(id))
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

        // POST: api/Eusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Euser>> PostEuser(Euser euser)
        {
            //_context.Eusers.Add(euser);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Eusers.Insert(euser);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetEuser", new { id = euser.Id }, euser);
        }

        // DELETE: api/Eusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuser(int id)
        {
            //var euser = await _context.Eusers.FindAsync(id);
            var euser = await _unitOfWork.Eusers.Get(q => q.Id == id);
            if (euser == null)
            {
                return NotFound();
            }

            //_context.Eusers.Remove(euser);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Eusers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> EuserExists(int id)
        {
            //return _context.Eusers.Any(e => e.Id == id);
            var euser = await _unitOfWork.Eusers.Get(q => q.Id == id);
            return euser != null;
        }
    }
}
