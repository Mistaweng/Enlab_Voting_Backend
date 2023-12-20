using Enlab_Voting_Backend.DbContext;
using Enlab_Voting_Backend.Model;
using Enlab_Voting_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Enlab_Voting_Backend.Implemantations
{
	public class ContestantInterfaceRepo : IContestantInterfaceRepo
	{
		private readonly ApplicationDbContext _dbContext;

		public ContestantInterfaceRepo(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> VoteForCandidateAsync(string voterId, string contestantId)
		{
			try
			{
				// Check if the voter has already voted for the candidate
				var existingVote = await _dbContext.Voters
					.FirstOrDefaultAsync(v => v.Id == voterId && v.Id == contestantId);
					;

				if (existingVote != null)
				{
					// Voter has already voted for the candidate, return a status indicating this
					return -1; // You can define your own status codes
				}

				// Create a new VoteRecord entity
				var newVote = new VoteRecord
				{
					VoterId = voterId,
					ContestantId = contestantId,
					createdAt = DateTime.UtcNow,
					
				};

				// Add the vote to the database
				_dbContext.VoteRecords.Add(newVote);

				// Save changes to the database
				await _dbContext.SaveChangesAsync();

				return 1; // Vote successful
			}
			catch (Exception)
			{
				return 0; // Vote failed
			}
		}

		public async Task<int> GetVoteCountAsync(string contestantId)
		{
			// Placeholder logic: Retrieve the vote count for a contestant from the database
			var voteCount = await _dbContext.Voters
				.Where(v => v.Id == contestantId)
				.CountAsync();

			return voteCount;
		}

		//public async Task<IEnumerable<VoteRecord>> GetVoteHistoryAsync(string contestantId)
		//{
		//	// Placeholder logic: Retrieve the vote history for a contestant from the database
		//	var voteHistory = await _dbContext.Voters
		//		.Where(v => v.Id == contestantId)
		//		.ToListAsync();

		//	return voteHistory;
		//}
	}


}
