namespace Enlab_Voting_Backend.Services
{
	public interface IEmailServices
	{
		Task SendEmailAsync(string email, string subject, string body);
	}
}
