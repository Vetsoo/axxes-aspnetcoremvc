using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.Web.Models
{
	public class CommentInputModel
	{
		public int SessionId { get; set; }

		[Required]
		[DisplayName("Comment")]
		public string Text { get; set; }
	}
}
