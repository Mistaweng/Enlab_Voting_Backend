using Microsoft.AspNetCore.Identity;

namespace Enlab_Voting_Backend.Model
{
	public class AppUserRole : IdentityRole<string>
	{
		public Guid Id { get; set; } = Guid.NewGuid();
	}
}
