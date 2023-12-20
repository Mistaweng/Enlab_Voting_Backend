using Enlab_Voting_Backend.Dtos;
using Enlab_Voting_Backend.Model;

namespace Enlab_Voting_Backend.Services
{
	public interface IAppUserRepository
	{
		Task<ApiResponse> CreateUser(SignUpDto userRequest);
		Task<AppUser> GetUserById(string userId);
	}
}
