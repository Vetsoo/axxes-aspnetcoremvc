using System;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.EntityFramework
{
	public class Comment
	{
		public Comment()
		{
			DateTime = DateTime.Now;
		}

		public int Id { get; set; }

		[Required]
		public string Text { get; set; }

		[Required]
		public DateTime DateTime { get; set; }

		public string AuthorId { get; set; }

		public virtual ApplicationUser Author { get; set; }

		public int SessionId { get; set; }

		[Required]
		public virtual Session Session { get; set; }
	}
}
