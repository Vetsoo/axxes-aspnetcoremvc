using Axxes.Haxx.EntityFramework;
using Axxes.Haxx.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Axxes.Haxx.Web.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
        }

        [HttpGet("{controller}/{sessionId}/{action}")]
        public IActionResult Create(int sessionId)
        {
            var model = new CommentInputModel { SessionId = sessionId };
            return PartialView("_Create", model);
        }

        [HttpPost("{controller}/{sessionId}/{action}")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int sessionId, CommentInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var comment = new Comment
                {
                    AuthorId = UserManager.GetUserId(this.User),
                    Text = model.Text,
                    DateTime = DateTime.Now,
                    SessionId = sessionId
                };

                this.Db.Comments.Add(comment);
                this.Db.SaveChanges();
                return RedirectToAction("ReplaceCommentsList", new { sessionId });
            }
            return View(model);
        }

        public IActionResult ReplaceCommentsList(int sessionId)
        {
            var comments = this.Db.Comments
                .Where(c => c.SessionId == sessionId)
                .Select(CommentViewModel.ViewModel);

            var model = new CommentListViewModel { Comments = comments }; 
            return PartialView("_CommentsList", model);
        }
    }
}