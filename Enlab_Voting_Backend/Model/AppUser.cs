using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Reflection;

namespace Enlab_Voting_Backend.Model
{
	public class AppUser : IdentityUser
	{
		public string? Title { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string? Image { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public Gender? Gender { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Country { get; set; }
		public bool? IsLockedOut { get; set; }
		public DateTime? LastOnline { get; set; }
		public bool? IsVerified { get; set; }
		public bool? IsArchived { get; set; }
		public bool? Active { get; set; }
		public string? VoterCode { get; set; }
		public DateTime? Timeleft { get; set; }
		public Setting? Setting { get; set; }
		public Wallet? Wallet { get; set; }

		public ICollection<Position> Positions { get; set; }
	
		public ICollection<Transaction> Transactions { get; set; }
		public ICollection<Voter> Voters { get; set; }
	}
}
