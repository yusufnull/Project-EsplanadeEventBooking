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
    public class CreatorController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public CreatorsController(ApplicationDbContext context)
        public CreatorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Creators
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Creator>>> GetCreators()
        public async Task<IActionResult> GetCreators()
        {
            //return await _context.Creators.ToListAsync();
            var creators = await _unitOfWork.Creators.GetAll();
            return Ok(creators);
        }

        // GET: api/Creators/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Creator>> GetCreator(int id)
        public async Task<IActionResult> GetCreator(int id)
        {
            //var creator = await _context.Creators.FindAsync(id);
            var creator = await _unitOfWork.Creators.Get(q => q.Id == id);

            if (creator == null)
            {
                return NotFound();
            }

            return Ok(creator);
        }

        // PUT: api/Creators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreator(int id, Creator creator)
        {
            if (id != creator.Id)
            {
                return BadRequest();
            }

            //_context.Entry(creator).State = EntityState.Modified;
            _unitOfWork.Creators.Update(creator);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);    
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CreatorExists(id))
                if (!await CreatorExists(id))
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

        // POST: api/Creators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Creator>> PostCreator(Creator creator)
        {
            //_context.Creators.Add(creator);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Creators.Insert(creator);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCreator", new { id = creator.Id }, creator);
        }

        // DELETE: api/Creators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreator(int id)
        {
            //var creator = await _context.Creators.FindAsync(id);
            var creator = await _unitOfWork.Creators.Get(q => q.Id == id);
            if (creator == null)
            {
                return NotFound();
            }

            //_context.Creators.Remove(creator);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Creators.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CreatorExists(int id)
        {
            //return _context.Creators.Any(e => e.Id == id);
            var creator = await _unitOfWork.Creators.Get(q => q.Id == id);
            return creator != null;
        }
    }
}
