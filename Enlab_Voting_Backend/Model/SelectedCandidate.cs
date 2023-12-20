namespace Enlab_Voting_Backend.Model
{
	public class SelectedCandidate : BaseEntity
	{
		public Contestant Contestant { get; set; }
		public string ContestantId { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
        public bool IsSelected { get; set; }

    }
}
