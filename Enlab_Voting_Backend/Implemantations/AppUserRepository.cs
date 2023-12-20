using Enlab_Voting_Backend.DbContext;
using Enlab_Voting_Backend.Dtos;
using Enlab_Voting_Backend.Model;
using Enlab_Voting_Backend.Services;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace Enlab_Voting_Backend.Implemantations
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ApplicationDbContext _dbContext;

		public AppUserRepository(UserManager<AppUser> userManager, ApplicationDbContext dbContext)
		{
			_userManager = userManager;
			_dbContext = dbContext;
		}

		public async Task<ApiResponse> CreateUser(SignUpDto userRequest)
		{
			var user = await _userManager.FindByEmailAsync(userRequest.Email);
			if (user != null) return ApiResponse.Failed("User already exist");
			user = new AppUser()
			{
				FirstName = userRequest.Firstname,
				LastName = userRequest.Lastname,
				Email = userRequest.Email,
				UserName = userRequest.Email
			};

			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var createUser = await _userManager.CreateAsync(user, userRequest.Password);
				if (!createUser.Succeeded) return ApiResponse.Failed(createUser.Errors);
				transaction.Complete();
				return ApiResponse.Success("User added successfully");
			}
		}

		public async Task<AppUser> GetUserById(string userId)
		{
			return await _dbContext.Users.FindAsync(userId);
		}
	}
}
