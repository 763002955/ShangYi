using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShangYi.Data;
using ShangYi.Models;
using Microsoft.AspNetCore.Http;

namespace ShangYi.Controllers.mvc
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CategoryController (ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Category
		public async Task<IActionResult> Index ()
		{
			return View (await _context.CategoryModel.ToListAsync ());
		}

		// GET: Category/Details/5
		public async Task<IActionResult> Details (int? id)
		{
			if (id == null)
			{
				return NotFound ();
			}

			var categoryModel = await _context.CategoryModel.SingleOrDefaultAsync(m => m.ID == id);
			if (categoryModel == null)
			{
				return NotFound ();
			}

			return View (categoryModel);
		}

		// GET: Category/Create
		public IActionResult Create ()
		{
			return View ();
		}

		// POST: Category/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create (CategoryModel categoryModel, IFormFile ThumbnailFile)
		{
			if (ModelState.IsValid && ThumbnailFile != null && ThumbnailFile.Length > 0)
			{
				var thumbnail = new BlobModel ();
				thumbnail.FileName =
					ThumbnailFile.FileName.Substring (ThumbnailFile.FileName.LastIndexOf ('\\') + 1);
				thumbnail.Content = new byte[ThumbnailFile.Length];
				ThumbnailFile.OpenReadStream ().Read (thumbnail.Content, 0, (int) ThumbnailFile.Length);
				_context.Add (thumbnail);
				await _context.SaveChangesAsync ();

				categoryModel.Thumbnail = thumbnail.ID;
				_context.Add (categoryModel);
				await _context.SaveChangesAsync ();

				return RedirectToAction ("Index");
			}

			foreach (var value in ModelState.Values)
				foreach (var error in value.Errors)
					ViewData["Error"] += error.ErrorMessage + ";";

			if (ThumbnailFile == null || ThumbnailFile.Length == 0)
				ViewData["Error"] += "No Thumbnail;";
			return View (categoryModel);
		}

		// GET: Category/Edit/5
		public async Task<IActionResult> Edit (int? id)
		{
			if (id == null)
			{
				return NotFound ();
			}

			var categoryModel = await _context.CategoryModel.SingleOrDefaultAsync(m => m.ID == id);
			if (categoryModel == null)
			{
				return NotFound ();
			}
			return View (categoryModel);
		}

		// POST: Category/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit (int id, CategoryModel categoryModel, IFormFile ThumbnailFile)
		{
			if (id != categoryModel.ID)
			{
				return NotFound ();
			}

			if (ModelState.IsValid)
			{
				try
				{
					if (ThumbnailFile != null && ThumbnailFile.Length > 0)
					{
						var thumbnail = new BlobModel ();
						thumbnail.FileName =
							ThumbnailFile.FileName.Substring (ThumbnailFile.FileName.LastIndexOf ('\\') + 1);
						thumbnail.Content = new byte[ThumbnailFile.Length];
						ThumbnailFile.OpenReadStream ().Read (thumbnail.Content, 0, (int) ThumbnailFile.Length);
						_context.Add (thumbnail);
						await _context.SaveChangesAsync ();

						categoryModel.Thumbnail = thumbnail.ID;
						_context.Update (categoryModel);
					}
					else
					{
						_context.Update (categoryModel);
						// Leave it unmodified
						_context.Entry (categoryModel).Property (m => m.Thumbnail).IsModified = false;
					}
					await _context.SaveChangesAsync ();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoryModelExists (categoryModel.ID))
					{
						return NotFound ();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction ("Index");
			}
			return View (categoryModel);
		}

		// GET: Category/Delete/5
		public async Task<IActionResult> Delete (int? id)
		{
			if (id == null)
			{
				return NotFound ();
			}

			var categoryModel = await _context.CategoryModel.SingleOrDefaultAsync(m => m.ID == id);
			if (categoryModel == null)
			{
				return NotFound ();
			}

			return View (categoryModel);
		}

		// POST: Category/Delete/5
		[HttpPost, ActionName ("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed (int id)
		{
			var categoryModel = await _context.CategoryModel.SingleOrDefaultAsync(m => m.ID == id);
			_context.CategoryModel.Remove (categoryModel);
			await _context.SaveChangesAsync ();
			return RedirectToAction ("Index");
		}

		private bool CategoryModelExists (int id)
		{
			return _context.CategoryModel.Any (e => e.ID == id);
		}
	}
}
