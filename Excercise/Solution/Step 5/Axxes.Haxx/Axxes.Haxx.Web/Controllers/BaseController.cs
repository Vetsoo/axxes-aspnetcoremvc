using Axxes.Haxx.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.Haxx.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ApplicationDbContext Db;

        protected UserManager<ApplicationUser> UserManager;

        public BaseController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            Db = db;
            UserManager = userManager;
        }

        public bool IsAdmin()
        {
            var currentUser = this.UserManager.GetUserAsync(this.User).Result;
            var isAdmin = currentUser != null && this.UserManager.IsInRoleAsync(currentUser, "ADMIN").Result;
            return isAdmin;
        }
    }
}