using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APITest
{
    public class Program
    {
		private static async Task MainScheme (
			Func<HttpClient, Task<HttpResponseMessage>> fn)
		{
			using (var client = new HttpClient ())
			{
				try
				{
					var result = await fn (client);
					result.EnsureSuccessStatusCode ();
					var str = await result.Content.ReadAsStringAsync ();
					Console.WriteLine (str);
				}
				catch (Exception ex)
				{
					Console.WriteLine (ex.Message);
				}
				Console.ReadKey ();
			}
		}

		public static void Main (string[] args)
		{
			MainScheme ((client) =>
			{
				var obj = new { name = "Jack", score = 0.5 };
				var jsonStr = JsonConvert.SerializeObject (obj);
				Console.WriteLine (jsonStr);
				return client.PostAsync ("http://localhost:2081/api/MyClasses/",
					new StringContent(jsonStr, Encoding.UTF8, "application/json"));
			}).Wait ();
		}
	}
}
