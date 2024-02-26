using Axxes.Haxx.EntityFramework;
using Axxes.Haxx.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
					SpeakerId = this.UserManager.GetUserId(this.User),
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
			return View();
		}
	}
}