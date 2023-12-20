using Enlab_Voting_Backend.Dtos;

namespace Enlab_Voting_Backend.Services
{
	public interface IUserInterfaceRepository
	{
		Task<List<UserDto>> GetAllUsersAsync();
		Task<string> UpdateUserAsync(string id, UserDto userDto);
		Task<bool> DeleteUserAsync(string userId);

		Task<UserInfoDto> GetUserStatus(string id);
		Task<UserDto> GetUserByIdAsync(string id);
	}
}
