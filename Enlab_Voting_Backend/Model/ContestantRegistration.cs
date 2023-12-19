namespace Enlab_Voting_Backend.Model
{
	public class ContestantRegistration : BaseEntity
	{
        public string Fullname { get; set; }
        public Position Position { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Fees { get; set; }


    }
}
