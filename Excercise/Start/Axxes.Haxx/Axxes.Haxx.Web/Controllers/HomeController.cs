using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Axxes.Haxx.Web.Models;
using Axxes.Haxx.EntityFramework;
using System.Linq;
using System;

namespace Axxes.Haxx.Web.Controllers
{
	public class HomeController : BaseController
	{

		public HomeController(ApplicationDbContext db) : base(db)
		{
		}

		public IActionResult Index()
		{
			var sessions = Db.Sessions
				.OrderBy(s => s.DateTime)
				.Where(s => s.IsPublic)
				.Select(SessionViewModel.ViewModel);

			var upcommingSessions = sessions.Where(s => s.DateTime > DateTime.Now);
			var passedSessions = sessions.Where(s => s.DateTime <= DateTime.Now);

			return View(new UpcomingPassedSessionViewModel 
			{
				PassedSessions = passedSessions,
				UpcommingSessions = upcommingSessions
			});
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
