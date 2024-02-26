using System.Collections.Generic;

namespace Axxes.Haxx.Web.Models
{
	public class UpcomingPassedSessionViewModel
	{
		public IEnumerable<SessionViewModel> UpcommingSessions { get; set; }
		public IEnumerable<SessionViewModel> PassedSessions { get; set; }
	}
}
