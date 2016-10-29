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
    public class HiringController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HiringController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Hiring
        public async Task<IActionResult> Index()
        {
            return View(await _context.HiringModel.ToListAsync());
        }

        // GET: Hiring/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiringModel = await _context.HiringModel.SingleOrDefaultAsync(m => m.id == id);
            if (hiringModel == null)
            {
                return NotFound();
            }

            return View(hiringModel);
        }

        // GET: Hiring/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hiring/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Details,Location,PhoneNumber,Position,Salary,TimeStamp,UID")] HiringModel hiringModel)
        {
            if (ModelState.IsValid)
            {
                hiringModel.TimeStamp = DateTime.Now;
                _context.Add(hiringModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hiringModel);
        }

        // GET: Hiring/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiringModel = await _context.HiringModel.SingleOrDefaultAsync(m => m.id == id);
            if (hiringModel == null)
            {
                return NotFound();
            }
            return View(hiringModel);
        }

        // POST: Hiring/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Details,Location,PhoneNumber,Position,Salary,TimeStamp,UID")] HiringModel hiringModel)
        {
            if (id != hiringModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hiringModel.TimeStamp = DateTime.Now;
                    _context.Update(hiringModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HiringModelExists(hiringModel.id))
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
            return View(hiringModel);
        }

        // GET: Hiring/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiringModel = await _context.HiringModel.SingleOrDefaultAsync(m => m.id == id);
            if (hiringModel == null)
            {
                return NotFound();
            }

            return View(hiringModel);
        }

        // POST: Hiring/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hiringModel = await _context.HiringModel.SingleOrDefaultAsync(m => m.id == id);
            _context.HiringModel.Remove(hiringModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HiringModelExists(int id)
        {
            return _context.HiringModel.Any(e => e.id == id);
        }
    }
}
