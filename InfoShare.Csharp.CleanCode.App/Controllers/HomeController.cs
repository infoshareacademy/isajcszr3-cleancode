using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InfoShare.Csharp.CleanCode.App.Models;
using InfoShare.Csharp.CleanCode.Services;
using Microsoft.Extensions.Configuration;

namespace InfoShare.Csharp.CleanCode.App.Controllers
{
	public class HomeController : Controller
	{
		private IConfiguration Configuration;

		public HomeController(
			IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			var service = new MyAppService();
			ViewData["Message"] = service.GetAbout();

			return View();
		}

		public IActionResult Contact()
		{
			var service = new MyAppService();

			ViewData["Message"] = service.ContactPageTitle;

			if (Configuration["Instance"] == "GD")
			{
				ViewData["ContactData"] = service.GetContactAddressForGd();
			}
			else if (Configuration["Instance"] == "WAW")
			{
				service.GetContactAddressForGd();
			}

			ViewData["SupportEmail"] = service.GetEmail(1);
			ViewData["MarketingEmail"] = service.GetEmail(2);

			return View();
		}

		public IActionResult ClientList()
		{
			var service = new MyAppService();

			return View(service.GetOurClients());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}