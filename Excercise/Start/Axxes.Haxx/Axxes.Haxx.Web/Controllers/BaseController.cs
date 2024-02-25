using Axxes.Haxx.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.Haxx.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ApplicationDbContext Db;

        public BaseController(ApplicationDbContext db)
        {
            Db = db;
        }
    }
}