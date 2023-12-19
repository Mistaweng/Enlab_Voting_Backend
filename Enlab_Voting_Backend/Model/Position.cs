namespace Enlab_Voting_Backend.Model
{
	public class Position : BaseEntity
	{
        public string President { get; set; }
        public string VicePresident { get; set; }
        public string Secretary { get; set; }
        public string ViceSecretary { get; set; }
        public string Treasurer { get; set; }
        public string FinancialSecretary { get; set; }
        public string PRO { get; set; }
        public string Welfare { get; set; }
    }
}
