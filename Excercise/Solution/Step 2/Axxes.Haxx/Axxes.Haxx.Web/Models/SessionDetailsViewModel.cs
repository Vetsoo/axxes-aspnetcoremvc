using Axxes.Haxx.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Axxes.Haxx.Web.Models
{
	public class SessionDetailsViewModel
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string SpeakerId { get; set; }

		public IEnumerable<CommentViewModel> Comments { get; set; }

		public static Expression<Func<Session, SessionDetailsViewModel>> ViewModel
		{
			get
			{
				return e => new SessionDetailsViewModel()
				{
					Id = e.Id,
					Description = e.Description,
					Comments = e.Comments.AsQueryable().Select(CommentViewModel.ViewModel).ToList(),
					SpeakerId = e.SpeakerId
				};
			}
		}
	}
}
