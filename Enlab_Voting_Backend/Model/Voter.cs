namespace Enlab_Voting_Backend.Model
{
	public class Voter : BaseEntity
	{
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Amount { get; set; }
        public int NoOfVotes { get; set; }
        public SelectedCandidate SelectedCandidate { get; set; }
    }
}
