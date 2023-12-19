namespace Enlab_Voting_Backend.Model
{
	public class UserOTP : BaseEntity
	{
		public string Email { get; set; }
		public string OTP { get; set; }
		public DateTime Expiration { get; set; }
	}
}
