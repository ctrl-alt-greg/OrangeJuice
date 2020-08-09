using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace OrangeJuice.Controllers 
{
	public class HelloWorldController : Controller
	{
		// GET /HelloWorld
		public IActionResult Index()
		{
			return View();
		}

		// Get /HelloWorld/Welcome
		public IActionResult Welcome(string name, int numTimes = 4)
		{
			ViewData["Name"] = name;
			ViewData["NumTimes"] = numTimes;

			return View();
		}
	}
}