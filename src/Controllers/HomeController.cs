using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShangYi.Models;

namespace ShangYi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult hello (string msg)
		{
			return Json (new { Msg = msg });
		}

		public IActionResult haha ()
		{
			MyClass obj = new MyClass();
			obj.name = "John";
			obj.id = 9;
			obj.score = 0.5;
			return Json (obj);
		}

        public IActionResult Error()
        {
            return View();
        }
    }
}
