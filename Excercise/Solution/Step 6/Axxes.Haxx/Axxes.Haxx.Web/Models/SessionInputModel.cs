using Axxes.Haxx.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.Web.Models
{
	public class SessionInputModel
	{
		[Required]
		[StringLength(200, MinimumLength = 1)]
		[Display(Name = "Title *")]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Date and time *")]
		public DateTime DateTime { get; set; }

		public string Description { get; set; }

		[MaxLength(200)]
		public string Category { get; set; }

		[Display(Name = "Is Public?")]
		public bool IsPublic { get; set; }

		public static SessionInputModel CreateSessionInputModel(Session session)
		{
			return new SessionInputModel
			{
				Title = session.Title,
				DateTime = session.DateTime,
				Category = session.Category,
				Description = session.Description,
				IsPublic = session.IsPublic
			};
		}
	}
}
