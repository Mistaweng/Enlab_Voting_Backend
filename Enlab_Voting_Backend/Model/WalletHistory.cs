namespace Enlab_Voting_Backend.Model
{
	public class WalletHistory : BaseEntity
	{
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Reference { get; set; }
		public string Details { get; set; }
		public string WalletAppUserId { get; set; }
		public Wallet Wallet { get; set; }
	}
}
