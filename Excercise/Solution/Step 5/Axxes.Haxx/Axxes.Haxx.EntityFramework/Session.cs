using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.EntityFramework
{
	public class Session
	{
		public Session()
		{
			IsPublic = true;
			DateTime = DateTime.Now;
			Comments = new List<Comment>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Title { get; set; }

		[Required]
		public DateTime DateTime { get; set; }

		public string SpeakerId { get; set; }

		public string Description { get; set; }

		[MaxLength(200)]
		public string Category { get; set; }

		public bool IsPublic { get; set; }

		public virtual ApplicationUser Speaker { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }
	}
}
