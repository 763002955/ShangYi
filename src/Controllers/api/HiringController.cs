using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShangYi.Data;
using ShangYi.Models;

namespace ShangYi.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Hiring")]
    public class HiringController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HiringController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hiring
        [HttpGet]
        public IEnumerable<HiringModel> GetHiringModel()
        {
            return _context.HiringModel;
        }

        // GET: api/Hiring/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHiringModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HiringModel hiringModel = await _context.HiringModel.SingleOrDefaultAsync(m => m.id == id);

            if (hiringModel == null)
            {
                return NotFound();
            }

            return Ok(hiringModel);
        }

        // PUT: api/Hiring/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiringModel([FromRoute] int id, [FromBody] HiringModel hiringModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hiringModel.id)
            {
                return BadRequest();
            }

            _context.Entry(hiringModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiringModelExists(id))
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

        // POST: api/Hiring
        [HttpPost]
        public async Task<IActionResult> PostHiringModel([FromBody] HiringModel hiringModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HiringModel.Add(hiringModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiringModelExists(hiringModel.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHiringModel", new { id = hiringModel.id }, hiringModel);
        }

        // DELETE: api/Hiring/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiringModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HiringModel hiringModel = await _context.HiringModel.SingleOrDefaultAsync(m => m.id == id);
            if (hiringModel == null)
            {
                return NotFound();
            }

            _context.HiringModel.Remove(hiringModel);
            await _context.SaveChangesAsync();

            return Ok(hiringModel);
        }

        private bool HiringModelExists(int id)
        {
            return _context.HiringModel.Any(e => e.id == id);
        }
    }
}