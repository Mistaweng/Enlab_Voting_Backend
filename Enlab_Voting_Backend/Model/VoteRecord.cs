namespace Enlab_Voting_Backend.Model
{
	public class VoteRecord : BaseEntity
	{
        public Contestant Contestant { get; set; }
        public int TotalVotes { get; set; }
        public string VoterId { get; set; }
        public string ContestantId { get; set; }
        public DateTime? createdAt { get; set; }



    }
}
