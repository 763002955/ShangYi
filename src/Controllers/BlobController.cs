using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShangYi.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;

namespace ShangYi.Controllers
{
	public class BlobController : Controller
	{
		private readonly ApplicationDbContext _context;

		public BlobController (ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index (int? id)
		{
			if (id == null)
				return NotFound ();

			var blob = await _context.BlobModel.SingleOrDefaultAsync (m => m.ID == id);
			if (blob == null)
				return NotFound ();

			var stream = new MemoryStream (blob.Content);
			Response.Headers.Add ("Content-Disposition",
				"attachment; filename=" + Uri.EscapeDataString (blob.FileName));
			return new FileStreamResult (stream, "application/octet-stream");
		}
	}
}