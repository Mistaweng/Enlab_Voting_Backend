using System.ComponentModel.DataAnnotations;

namespace Enlab_Voting_Backend.Dtos
{
	public class ResetPasswordDTO
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
	}
}
