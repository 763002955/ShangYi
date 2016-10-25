﻿using System;
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
				client.BaseAddress = new Uri ("http://localhost:2081");

				var apiAddr = "/api/PhoneNumber/";
				var idAddr = "1002/";
				var obj = new { Department = "开发", /*Name = "哈哈",*/ Number = 12345 };

				var jsonStr = JsonConvert.SerializeObject (obj);
				Console.WriteLine (jsonStr);
				var content = new StringContent (jsonStr, Encoding.UTF8, "application/json");

				return client.PostAsync (apiAddr, content);
				return client.GetAsync (apiAddr + idAddr);
				return client.GetAsync (apiAddr);
				return client.DeleteAsync (apiAddr + idAddr);
				return client.PutAsync (apiAddr + idAddr, content);

				// Return Get/Post/Put/Delete Async
			}).Wait ();
		}
	}
}
