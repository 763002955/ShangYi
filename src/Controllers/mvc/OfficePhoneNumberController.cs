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
    public class OfficePhoneNumberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficePhoneNumberController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: OfficePhoneNumber
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneNumber
				.Where (m => m.Name != null).ToListAsync());
        }

        // GET: OfficePhoneNumber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumberModel = await _context.PhoneNumber.SingleOrDefaultAsync(m => m.ID == id);
            if (phoneNumberModel == null)
            {
                return NotFound();
            }

            return View(phoneNumberModel);
        }

        // GET: OfficePhoneNumber/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficePhoneNumber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Department,Name,Number")] PhoneNumberModel phoneNumberModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneNumberModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(phoneNumberModel);
        }

        // GET: OfficePhoneNumber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumberModel = await _context.PhoneNumber.SingleOrDefaultAsync(m => m.ID == id);
            if (phoneNumberModel == null)
            {
                return NotFound();
            }
            return View(phoneNumberModel);
        }

        // POST: OfficePhoneNumber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Department,Name,Number")] PhoneNumberModel phoneNumberModel)
        {
            if (id != phoneNumberModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneNumberModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneNumberModelExists(phoneNumberModel.ID))
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
            return View(phoneNumberModel);
        }

        // GET: OfficePhoneNumber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumberModel = await _context.PhoneNumber.SingleOrDefaultAsync(m => m.ID == id);
            if (phoneNumberModel == null)
            {
                return NotFound();
            }

            return View(phoneNumberModel);
        }

        // POST: OfficePhoneNumber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneNumberModel = await _context.PhoneNumber.SingleOrDefaultAsync(m => m.ID == id);
            _context.PhoneNumber.Remove(phoneNumberModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PhoneNumberModelExists(int id)
        {
            return _context.PhoneNumber.Any(e => e.ID == id);
        }
    }
}
