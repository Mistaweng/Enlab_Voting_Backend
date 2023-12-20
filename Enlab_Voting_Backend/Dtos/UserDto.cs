using Enlab_Voting_Backend.Model;

namespace Enlab_Voting_Backend.Dtos
{
	public class UserDto
	{
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string? Image { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public Gender? Gender { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Country { get; set; }
        public Position Position { get; set; }
    }
}
