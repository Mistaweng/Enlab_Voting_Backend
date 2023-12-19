namespace Enlab_Voting_Backend.Model
{
	public class Contestant : BaseEntity
	{
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }
        public int NoOfVotes { get; set; }
        public Wallet Wallet { get; set; }
    }
}
