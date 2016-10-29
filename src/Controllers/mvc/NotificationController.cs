using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShangYi.Data;
using ShangYi.Models;

namespace ShangYi.Controllers.mvc
{
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotificationModel.ToListAsync());
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationModel = await _context.NotificationModel.SingleOrDefaultAsync(m => m.id == id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            return View(notificationModel);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,PhoneNumber,TimeStamp,Title,UID,Uploader,content")] NotificationModel notificationModel)
        {
            if (ModelState.IsValid)
            {
                notificationModel.TimeStamp = DateTime.Now;
                _context.Add(notificationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(notificationModel);
        }

        // GET: Notification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationModel = await _context.NotificationModel.SingleOrDefaultAsync(m => m.id == id);
            if (notificationModel == null)
            {
                return NotFound();
            }
            return View(notificationModel);
        }

        // POST: Notification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,PhoneNumber,TimeStamp,Title,UID,Uploader,content")] NotificationModel notificationModel)
        {
            if (id != notificationModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    notificationModel.TimeStamp = DateTime.Now;
                    _context.Update(notificationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationModelExists(notificationModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(notificationModel);
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationModel = await _context.NotificationModel.SingleOrDefaultAsync(m => m.id == id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            return View(notificationModel);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificationModel = await _context.NotificationModel.SingleOrDefaultAsync(m => m.id == id);
            _context.NotificationModel.Remove(notificationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NotificationModelExists(int id)
        {
            return _context.NotificationModel.Any(e => e.id == id);
        }
    }
}
