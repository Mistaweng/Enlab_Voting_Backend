namespace Enlab_Voting_Backend.Model
{
	public class Setting : BaseEntity
	{
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}
