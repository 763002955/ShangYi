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
    [Route("api/CarPooling")]
    public class CarPoolingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarPoolingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarPooling
        [HttpGet]
        public IEnumerable<CarPoolingModel> GetCarPooling()
        {
            return _context.CarPooling;
        }

        // GET: api/CarPooling/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPoolingModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CarPoolingModel carPoolingModel = await _context.CarPooling.SingleOrDefaultAsync(m => m.id == id);

            if (carPoolingModel == null)
            {
                return NotFound();
            }

            return Ok(carPoolingModel);
        }

        // PUT: api/CarPooling/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarPoolingModel([FromRoute] int id, [FromBody] CarPoolingModel carPoolingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carPoolingModel.id)
            {
                return BadRequest();
            }

            carPoolingModel.TimeStamp = DateTime.Now;
            _context.Entry(carPoolingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarPoolingModelExists(id))
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

        // POST: api/CarPooling
        [HttpPost]
        public async Task<IActionResult> PostCarPoolingModel([FromBody] CarPoolingModel carPoolingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CarPooling.Add(carPoolingModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarPoolingModelExists(carPoolingModel.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarPoolingModel", new { id = carPoolingModel.id }, carPoolingModel);
        }

        // DELETE: api/CarPooling/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarPoolingModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CarPoolingModel carPoolingModel = await _context.CarPooling.SingleOrDefaultAsync(m => m.id == id);
            if (carPoolingModel == null)
            {
                return NotFound();
            }

            _context.CarPooling.Remove(carPoolingModel);
            await _context.SaveChangesAsync();

            return Ok(carPoolingModel);
        }

        private bool CarPoolingModelExists(int id)
        {
            return _context.CarPooling.Any(e => e.id == id);
        }
    }
}