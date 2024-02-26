using Axxes.Haxx.EntityFramework;
using System;
using System.Linq.Expressions;

namespace Axxes.Haxx.Web.Models
{
	public class SessionViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime DateTime { get; set; }
		public string Category { get; set; }
		public string Speaker { get; set; }

		public static Expression<Func<Session, SessionViewModel>> ViewModel
		{
			get 
			{
				return s => new SessionViewModel
				{
					Id = s.Id,
					Title = s.Title,
					DateTime = s.DateTime,
					Category = s.Category,
					Speaker = s.Speaker.FullName
				};
			}
		}
	}
}
