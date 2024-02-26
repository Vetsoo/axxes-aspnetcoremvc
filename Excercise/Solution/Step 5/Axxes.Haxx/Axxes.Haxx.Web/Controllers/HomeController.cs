using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Axxes.Haxx.Web.Models;
using Axxes.Haxx.EntityFramework;
using System.Linq;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Axxes.Haxx.Web.Controllers
{
	public class HomeController : BaseController
	{

		public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db, userManager)
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

		public IActionResult SessionDetailsById(int id)
		{
			var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier);
			var currentUserId = currentUser?.Value;
			var isAdmin = this.IsAdmin();
			var sessionDetails = this.Db.Sessions
				.Where(e => e.Id == id)
				.Where(e => e.IsPublic || isAdmin || (e.SpeakerId != null && e.SpeakerId == currentUserId))
				.Select(SessionDetailsViewModel.ViewModel)
				.FirstOrDefault();

			var isOwner = (sessionDetails != null && sessionDetails.SpeakerId != null &&
						   sessionDetails.SpeakerId == currentUserId);

			this.ViewBag.CanEdit = isOwner || isAdmin;

			return this.PartialView("_SessionDetails", sessionDetails);
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
