namespace Enlab_Voting_Backend.Services
{
	public interface IContestantInterfaceRepo
	{
		Task<int> VoteForCandidateAsync(string voterId, string contestantId);

		Task<int> GetVoteCountAsync(string contestantId);

		//Task<IEnumerable<VoteRecord>> GetVoteHistoryAsync(int contestantId);
	}
}
