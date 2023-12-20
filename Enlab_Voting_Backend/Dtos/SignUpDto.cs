using Enlab_Voting_Backend.Model;

namespace Enlab_Voting_Backend.Dtos
{
	public class SignUpDto
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string MiddleName { get; set; }
        public string ImageUrl { get; set; }
        public Position Position { get; set; }
    }
}
