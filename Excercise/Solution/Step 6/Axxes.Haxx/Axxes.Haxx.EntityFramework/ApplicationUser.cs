using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.EntityFramework
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FullName { get; set; }
	}
}
