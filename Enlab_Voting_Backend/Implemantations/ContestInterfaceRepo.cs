using Enlab_Voting_Backend.DbContext;
using Enlab_Voting_Backend.Model;
using Enlab_Voting_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Enlab_Voting_Backend.Implemantations
{
	public class ContestInterfaceRepo : IContestInterfaceRepo
	{
		private readonly ApplicationDbContext _dbContext;

		public ContestInterfaceRepo(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> RegisterCandidateAsync(ContestantRegistration registrationInfo)
		{
			try
			{
				// Create a new Candidate entity from registrationInfo
				var newCandidate = new ContestantRegistration
				{
					// Map properties from registrationInfo to Candidate
					Fullname = registrationInfo.Fullname,
					CreatedAt = registrationInfo.CreatedAt,
					Position = registrationInfo.Position,
					ImageUrl = registrationInfo.ImageUrl,
					Description = registrationInfo.Description,
					Fees = registrationInfo.Fees
				};

				// Add the candidate to the database
				_dbContext.RegisteredCandidates.Add(newCandidate);

				// Save changes to the database
				await _dbContext.SaveChangesAsync();

				return true; // Registration successful
			}
			catch (Exception)
			{
				return false; // Registration failed
			}
		}

		public async Task<bool> PayForParticipationAsync(string contestantId, decimal paymentAmount)
		{
			try
			{
				// Retrieve the candidate from the database
				var contestant = await _dbContext.RegisteredCandidates.FindAsync(contestantId);

				if (contestant != null)
				{
					// Update candidate payment status and amount
					contestant.HasPaid = true;
					contestant.PaymentAmount = paymentAmount;

					// Save changes to the database
					await _dbContext.SaveChangesAsync();

					return true; // Payment successful
				}

				return false; // Candidate not found
			}
			catch (Exception)
			{
				return false; // Payment failed
			}
		}

		public async Task<IEnumerable<Contestant>> GetContestantsAsync()
		{
			// Retrieve all candidates from the database
			return await _dbContext.Contestants.ToListAsync();
		}

		public async Task<VoteRecord> GetVoteResultAsync(string contestantId)
		{
			// Implementation to calculate and retrieve the vote result for a candidate
			// This could involve querying votes and aggregating results
			// ...

			return new VoteRecord
			{
				ContestantId = contestantId,
				TotalVotes = 0 // Placeholder, replace with actual calculation
			};
		}
	}

}
