using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShangYi.Data;
using ShangYi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Controllers
{
	public class BlobManager
	{
		public static async Task<int> SaveBlob (
			ApplicationDbContext context, IFormFile file)
		{
			var blob = new BlobModel
			{
				FileName = file.FileName.Substring (file.FileName.LastIndexOf ('\\') + 1),
				Content = new byte[file.Length]
			};
			file.OpenReadStream ().Read (blob.Content, 0, (int) file.Length);

			context.Add (blob);
			await context.SaveChangesAsync ();
			return blob.ID;
		}

		public static async Task DeleteBlob (
			ApplicationDbContext context, int id)
		{
			var blob = new BlobModel { ID = id };
			context.Entry (blob).State = EntityState.Deleted;
			await context.SaveChangesAsync ();
		}
	}
}
