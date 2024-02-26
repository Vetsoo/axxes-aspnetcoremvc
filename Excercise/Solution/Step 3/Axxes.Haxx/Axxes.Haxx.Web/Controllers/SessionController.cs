using Axxes.Haxx.EntityFramework;
using Axxes.Haxx.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Axxes.Haxx.Web.Controllers
{
	[Authorize]
    public class SessionController : BaseController
    {
        public SessionController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
        }

        public IActionResult CreateSession()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateSession(SessionInputModel model)
		{
			if (model != null && ModelState.IsValid)
			{
				var session = new Session
				{
					SpeakerId = UserManager.GetUserId(this.User),
					Title = model.Title,
					DateTime = model.DateTime,
					Category = model.Category,
					Description = model.Description,
					IsPublic = model.IsPublic
				};

				this.Db.Sessions.Add(session);
				this.Db.SaveChanges();
				return RedirectToAction("MySessions");
			}

			return View(model);
		}

		public IActionResult MySessions()
		{
			var currentUserId = UserManager.GetUserId(this.User);
			var sessions = Db.Sessions
				.Where(s => s.SpeakerId == currentUserId)
				.OrderBy(s => s.DateTime)
				.Select(SessionViewModel.ViewModel);

			var upcommingSessions = sessions.Where(s => s.DateTime > DateTime.Now);
			var passedSessions = sessions.Where(s => s.DateTime <= DateTime.Now);

			return View(new UpcomingPassedSessionViewModel
			{
				PassedSessions = passedSessions,
				UpcommingSessions = upcommingSessions
			});
		}
	}
}