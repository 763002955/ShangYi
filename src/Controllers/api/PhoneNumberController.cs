using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShangYi.Data;
using ShangYi.Models;

namespace ShangYi.Controllers
{
    [Produces("application/json")]
    [Route("api/PhoneNumber")]
    public class apiPhoneNumberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public apiPhoneNumberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PhoneNumber
        [HttpGet]
        public IEnumerable<PhoneNumberModel> GetPhoneNumber()
        {
            return _context.PhoneNumber;
        }

        // GET: api/PhoneNumber/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneNumberModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PhoneNumberModel phoneNumberModel = await _context.PhoneNumber.SingleOrDefaultAsync(m => m.ID == id);

            if (phoneNumberModel == null)
            {
                return NotFound();
            }

            return Ok(phoneNumberModel);
        }

        // PUT: api/PhoneNumber/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneNumberModel([FromRoute] int id, [FromBody] PhoneNumberModel phoneNumberModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneNumberModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(phoneNumberModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(phoneNumberModel);
        }

        // POST: api/PhoneNumber
        [HttpPost]
        public async Task<IActionResult> PostPhoneNumberModel([FromBody] PhoneNumberModel phoneNumberModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PhoneNumber.Add(phoneNumberModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhoneNumberModelExists(phoneNumberModel.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhoneNumberModel", new { id = phoneNumberModel.ID }, phoneNumberModel);
        }

        // DELETE: api/PhoneNumber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumberModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PhoneNumberModel phoneNumberModel = await _context.PhoneNumber.SingleOrDefaultAsync(m => m.ID == id);
            if (phoneNumberModel == null)
            {
                return NotFound();
            }

            _context.PhoneNumber.Remove(phoneNumberModel);
            await _context.SaveChangesAsync();

            return Ok(phoneNumberModel);
        }

        private bool PhoneNumberModelExists(int id)
        {
            return _context.PhoneNumber.Any(e => e.ID == id);
        }
    }
}