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
    public class CarPoolingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarPoolingController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CarPooling
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarPooling.ToListAsync());
        }

        // GET: CarPooling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPoolingModel = await _context.CarPooling.SingleOrDefaultAsync(m => m.id == id);
            if (carPoolingModel == null)
            {
                return NotFound();
            }

            return View(carPoolingModel);
        }

        // GET: CarPooling/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarPooling/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarPoolingModel carPoolingModel)
        {
            if (ModelState.IsValid)
            {
                carPoolingModel.TimeStamp = DateTime.Now;
                _context.Add(carPoolingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(carPoolingModel);
        }

        // GET: CarPooling/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPoolingModel = await _context.CarPooling.SingleOrDefaultAsync(m => m.id == id);
            if (carPoolingModel == null)
            {
                return NotFound();
            }
            return View(carPoolingModel);
        }

        // POST: CarPooling/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,From,Name,PhoneNumber,Time,TimeStamp,To,UID")] CarPoolingModel carPoolingModel)
        {
            if (id != carPoolingModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    carPoolingModel.TimeStamp = DateTime.Now;
                    _context.Update(carPoolingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPoolingModelExists(carPoolingModel.id))
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
            return View(carPoolingModel);
        }

        // GET: CarPooling/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPoolingModel = await _context.CarPooling.SingleOrDefaultAsync(m => m.id == id);
            if (carPoolingModel == null)
            {
                return NotFound();
            }

            return View(carPoolingModel);
        }

        // POST: CarPooling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carPoolingModel = await _context.CarPooling.SingleOrDefaultAsync(m => m.id == id);
            _context.CarPooling.Remove(carPoolingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CarPoolingModelExists(int id)
        {
            return _context.CarPooling.Any(e => e.id == id);
        }
    }
}
