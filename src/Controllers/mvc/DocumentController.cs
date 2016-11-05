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
using System.Net.Http;
using System.Net;
using System.IO;

namespace ShangYi.Controllers.mvc
{
	public class DocumentController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DocumentController (ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Document
		public async Task<IActionResult> Index ()
		{
			return View (await _context.DocumentModel.ToListAsync ());
		}

		// GET: Document/Details/5
		public async Task<IActionResult> Details (int? id)
		{
			if (id == null)
			{
				return NotFound ();
			}

			var documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.id == id);
			if (documentModel == null)
			{
				return NotFound ();
			}

			return View (documentModel);
		}

		public async Task<IActionResult> DownloadAttachment (int? id)
		{
			if (id == null)
				return NotFound ();

			var documentModel = await _context.DocumentModel.SingleOrDefaultAsync (m => m.id == id);
			if (documentModel == null)
				return NotFound ();

			var stream = new MemoryStream (documentModel.Attachment);
			return new FileStreamResult (stream, "application/octet-stream");
		}

		// GET: Document/Create
		public IActionResult Create ()
		{
			return View ();
		}

		// POST: Document/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create (DocumentModel documentModel, IFormFile AttachmentFile)
		{
			if (ModelState.IsValid && AttachmentFile != null && AttachmentFile.Length != 0)
			{
				documentModel.Attachment = new byte[AttachmentFile.Length];
				AttachmentFile.OpenReadStream ().Read (documentModel.Attachment, 0, (int) AttachmentFile.Length);
				documentModel.TimeStamp = DateTime.Now;
				_context.Add (documentModel);
				await _context.SaveChangesAsync ();
				return RedirectToAction ("Index");
			}
			return View (documentModel);
		}

		// GET: Document/Edit/5
		public async Task<IActionResult> Edit (int? id)
		{
			if (id == null)
			{
				return NotFound ();
			}

			var documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.id == id);
			if (documentModel == null)
			{
				return NotFound ();
			}
			return View (documentModel);
		}

		// POST: Document/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit (int id, [Bind ("id,Attachment,Content,Index,TimeStamp,Title,UID,Uploader")] DocumentModel documentModel)
		{
			if (id != documentModel.id)
			{
				return NotFound ();
			}

			if (ModelState.IsValid)
			{
				try
				{
					documentModel.TimeStamp = DateTime.Now;
					_context.Update (documentModel);
					await _context.SaveChangesAsync ();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!DocumentModelExists (documentModel.id))
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
			return View (documentModel);
		}

		// GET: Document/Delete/5
		public async Task<IActionResult> Delete (int? id)
		{
			if (id == null)
			{
				return NotFound ();
			}

			var documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.id == id);
			if (documentModel == null)
			{
				return NotFound ();
			}

			return View (documentModel);
		}

		// POST: Document/Delete/5
		[HttpPost, ActionName ("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed (int id)
		{
			var documentModel = await _context.DocumentModel.SingleOrDefaultAsync(m => m.id == id);
			_context.DocumentModel.Remove (documentModel);
			await _context.SaveChangesAsync ();
			return RedirectToAction ("Index");
		}

		private bool DocumentModelExists (int id)
		{
			return _context.DocumentModel.Any (e => e.id == id);
		}
	}
}
