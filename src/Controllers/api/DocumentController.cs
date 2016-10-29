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
    [Route("api/Document")]
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Document
        [HttpGet]
        public IEnumerable<DocumentModel> GetDocumentModel()
        {
            return _context.DocumentModel;
        }

        // GET: api/Document/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DocumentModel documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.id == id);

            if (documentModel == null)
            {
                return NotFound();
            }

            return Ok(documentModel);
        }

        // PUT: api/Document/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentModel([FromRoute] int id, [FromBody] DocumentModel documentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentModel.id)
            {
                return BadRequest();
            }

            _context.Entry(documentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentModelExists(id))
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

        // POST: api/Document
        [HttpPost]
        public async Task<IActionResult> PostDocumentModel([FromBody] DocumentModel documentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DocumentModel.Add(documentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentModelExists(documentModel.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocumentModel", new { id = documentModel.id }, documentModel);
        }

        // DELETE: api/Document/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DocumentModel documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.id == id);
            if (documentModel == null)
            {
                return NotFound();
            }

            _context.DocumentModel.Remove(documentModel);
            await _context.SaveChangesAsync();

            return Ok(documentModel);
        }

        private bool DocumentModelExists(int id)
        {
            return _context.DocumentModel.Any(e => e.id == id);
        }
    }
}