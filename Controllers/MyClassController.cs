using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShangYi.Data;
using ShangYi.Models;

namespace ShangYi.Controllers
{
    public class MyClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyClassController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MyClass
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyClass.ToListAsync());
        }

        // GET: MyClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myClass = await _context.MyClass.SingleOrDefaultAsync(m => m.id == id);
            if (myClass == null)
            {
                return NotFound();
            }

            return View(myClass);
        }

        // GET: MyClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,score")] MyClass myClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myClass);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(myClass);
        }

        // GET: MyClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myClass = await _context.MyClass.SingleOrDefaultAsync(m => m.id == id);
            if (myClass == null)
            {
                return NotFound();
            }
            return View(myClass);
        }

        // POST: MyClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,score")] MyClass myClass)
        {
            if (id != myClass.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyClassExists(myClass.id))
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
            return View(myClass);
        }

        // GET: MyClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myClass = await _context.MyClass.SingleOrDefaultAsync(m => m.id == id);
            if (myClass == null)
            {
                return NotFound();
            }

            return View(myClass);
        }

        // POST: MyClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myClass = await _context.MyClass.SingleOrDefaultAsync(m => m.id == id);
            _context.MyClass.Remove(myClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MyClassExists(int id)
        {
            return _context.MyClass.Any(e => e.id == id);
        }
    }
}
