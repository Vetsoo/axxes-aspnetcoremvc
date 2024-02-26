using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Axxes.Haxx.EntityFramework
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Session> Sessions { get; set; }
		public DbSet<Comment> Comments { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			CreateSessions(builder);
		}

		private void CreateSessions(ModelBuilder builder)
		{
			builder.Entity<Session>().HasData(
				new Session
				{
					Id = 1,
					Title = "Allround .NET",
					DateTime = DateTime.Now.AddDays(-5),
					Description = "This is my first session.",
					Category = ".NET",
					IsPublic = true
				},
				new Session
				{
					Id = 2,
					Title = "Java, no way!",
					DateTime = DateTime.Now.AddDays(3),
					Description = "This is my second session.",
					Category = "Java",
					IsPublic = true
				},
				new Session
				{
					Id = 3,
					Title = "VS Code tutorial!",
					DateTime = DateTime.Now.AddDays(-2),
					Description = "This is my third session.",
					Category = ".NET",
					IsPublic = false
				}
			);

			builder.Entity<Comment>().HasData(
				new Comment
				{
					Id = 1,
					DateTime = DateTime.Now,
					Text = "Well done!",
					SessionId = 1
				},
				new Comment
				{
					Id = 2,
					DateTime = DateTime.Now,
					Text = "Super!",
					SessionId = 2
				}
				);
		}
	}
}
