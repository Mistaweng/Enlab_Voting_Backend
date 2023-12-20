using Enlab_Voting_Backend.Model;

namespace Enlab_Voting_Backend.Services
{
	public interface IContestInterfaceRepo
	{
		Task<bool> RegisterCandidateAsync(ContestantRegistration registrationInfo);

		Task<bool> PayForParticipationAsync(string contestantId, decimal paymentAmount);

		Task<IEnumerable<Contestant>> GetContestantsAsync();

		Task<VoteRecord> GetVoteResultAsync(string contestantId);
	}
}
