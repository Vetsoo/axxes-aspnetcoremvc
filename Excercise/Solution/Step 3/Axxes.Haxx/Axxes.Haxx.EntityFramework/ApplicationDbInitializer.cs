using Microsoft.AspNetCore.Identity;

namespace Axxes.Haxx.EntityFramework
{
	public class ApplicationDbInitializer
	{
		public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
		{
			var adminRoleExists = roleManager.RoleExistsAsync("ADMIN").Result;
			if (!adminRoleExists) 
			{
				_ = roleManager.CreateAsync(new IdentityRole("ADMIN")).Result;
			}

			if (userManager.FindByEmailAsync("admin@admin.com").Result == null) 
			{
				var hasher = new PasswordHasher<ApplicationUser>();
				var user = new ApplicationUser
				{
					UserName = "admin@admin.com",
					Email = "admin@admin.com",
					FullName = "System Administrator",
					PasswordHash = hasher.HashPassword(null, "admin")
				};

				var result = userManager.CreateAsync(user, "admin").Result;

				if (result.Succeeded) 
				{
					_ = userManager.AddToRoleAsync(user, "ADMIN").Result;
				}
			}
		}
	}
}
