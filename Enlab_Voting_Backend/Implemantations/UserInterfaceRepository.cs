using Enlab_Voting_Backend.DbContext;
using Enlab_Voting_Backend.Dtos;
using Enlab_Voting_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Enlab_Voting_Backend.Implemantations
{
	public class UserInterfaceRepository : IUserInterfaceRepository
	{

		private readonly ApplicationDbContext _db;

		public UserInterfaceRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<List<UserDto>> GetAllUsersAsync()
		{
			var users = await _db.Users.ToListAsync();

			return users.Select(user => new UserDto
			{
				Title = user.Title,
				FirstName = user.FirstName,
				MiddleName = user.MiddleName,
				LastName = user.LastName,
				Image = user.Image,
				Address = user.Address,
				City = user.City,
				State = user.State,
				Gender = user.Gender,
				DateOfBirth = user.DateOfBirth,
				Country = user.Country,
			}).ToList();
		}
		public async Task<string> UpdateUserAsync(string id, UserDto userDto)
		{
			var user = await _db.Users.FindAsync(id);

			if (user == null)
				return "User not found.";

			user.Title = user.Title;
			user.FirstName = user.FirstName;
			user.MiddleName = user.MiddleName;
			user.LastName = user.LastName;
			user.Image = user.Image;
			user.Address = user.Address;
			user.City = user.City;
			user.State = user.State;
			user.Gender = user.Gender;
			user.DateOfBirth = user.DateOfBirth;
			user.Country = user.Country;

			try
			{
				await _db.SaveChangesAsync();
				return "User updated successfully.";
			}
			catch (Exception)
			{
				return "User failed to update.";
			}
		}

		public async Task<UserDto> GetUserByIdAsync(string id)
		{
			var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
			if (user == null)
			{
				return null;
			}

			return new UserDto
			{
				Title = user.Title,
				FirstName = user.FirstName,
				MiddleName = user.MiddleName,
				LastName = user.LastName,
				Image = user.Image,
				Address = user.Address,
				City = user.City,
				State = user.State,
				Gender = user.Gender,
				DateOfBirth = user.DateOfBirth,
				Country = user.Country
			};
		}
		public async Task<bool> DeleteUserAsync(string userId)
		{
			try
			{
				var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);

				if (user != null)
				{
					_db.Users.Remove(user);
					await _db.SaveChangesAsync();

					return true;
				}
				else
				{
					Console.WriteLine($"User not found with ID: {userId}");
					return false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
				return false;
			}
		}


		//get user status
		public async Task<UserInfoDto> GetUserStatus(string id)
		{

			var getData = await _db .SelectedCandidates.Include(u => u.AppUser).OrderByDescending(o => o.Contestant).FirstOrDefaultAsync(x => x.Id == id);

			if (getData == null) return null;

			UserInfoDto userInfo = new UserInfoDto
			{
				LastOnline = getData.AppUser.LastOnline,
				IsVerified = getData.AppUser.IsVerified,
				Active = getData.AppUser.Active,
				IsSelected = getData.IsSelected,
				IsDeleted = getData.IsDeleted,
			};

			return userInfo;

		}


	}
}
