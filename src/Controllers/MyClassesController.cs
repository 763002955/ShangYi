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
    [Route("api/MyClasses")]
    public class MyClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MyClasses
        [HttpGet]
        public IEnumerable<MyClass> GetMyClass()
        {
            return _context.MyClass;
        }

        // GET: api/MyClasses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyClass myClass = await _context.MyClass.SingleOrDefaultAsync(m => m.id == id);

            if (myClass == null)
            {
                return NotFound();
            }

            return Ok(myClass);
        }

        // PUT: api/MyClasses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyClass([FromRoute] int id, [FromBody] MyClass myClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myClass.id)
            {
                return BadRequest();
            }

            _context.Entry(myClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyClassExists(id))
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

        // POST: api/MyClasses
        [HttpPost]
        public async Task<IActionResult> PostMyClass([FromBody] MyClass myClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyClass.Add(myClass);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MyClassExists(myClass.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMyClass", new { id = myClass.id }, myClass);
        }

        // DELETE: api/MyClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MyClass myClass = await _context.MyClass.SingleOrDefaultAsync(m => m.id == id);
            if (myClass == null)
            {
                return NotFound();
            }

            _context.MyClass.Remove(myClass);
            await _context.SaveChangesAsync();

            return Ok(myClass);
        }

        private bool MyClassExists(int id)
        {
            return _context.MyClass.Any(e => e.id == id);
        }
    }
}