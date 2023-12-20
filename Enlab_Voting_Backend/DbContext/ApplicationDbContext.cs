using Enlab_Voting_Backend.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Enlab_Voting_Backend.DbContext
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Contestant> Contestants { get; set; }
		public DbSet<ContestantRegistration> RegisteredCandidates { get; set; }
		public DbSet<Voter> Voters { get; set; }
		public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Position> ContestPositions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AppUserPermission> Permissions { get; set; }
        public DbSet<FileUploadModel> UploadedFiles { get; set; }
        public DbSet<SelectedCandidate> SelectedCandidates { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> WalletHistories { get; set; }
        public DbSet<UserOTP> userOTPs { get; set; }
        public DbSet<VoteRecord> VoteRecords { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


		}
	}
}
