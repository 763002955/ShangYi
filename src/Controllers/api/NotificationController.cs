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
    [Route("api/Notification")]
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notification
        [HttpGet]
        public IEnumerable<NotificationModel> GetNotificationModel()
        {
            return _context.NotificationModel;
        }

        // GET: api/Notification/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NotificationModel notificationModel = await _context.NotificationModel.SingleOrDefaultAsync(m => m.id == id);

            if (notificationModel == null)
            {
                return NotFound();
            }

            return Ok(notificationModel);
        }

        // PUT: api/Notification/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationModel([FromRoute] int id, [FromBody] NotificationModel notificationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationModel.id)
            {
                return BadRequest();
            }

            _context.Entry(notificationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationModelExists(id))
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

        // POST: api/Notification
        [HttpPost]
        public async Task<IActionResult> PostNotificationModel([FromBody] NotificationModel notificationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NotificationModel.Add(notificationModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NotificationModelExists(notificationModel.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNotificationModel", new { id = notificationModel.id }, notificationModel);
        }

        // DELETE: api/Notification/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NotificationModel notificationModel = await _context.NotificationModel.SingleOrDefaultAsync(m => m.id == id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            _context.NotificationModel.Remove(notificationModel);
            await _context.SaveChangesAsync();

            return Ok(notificationModel);
        }

        private bool NotificationModelExists(int id)
        {
            return _context.NotificationModel.Any(e => e.id == id);
        }
    }
}