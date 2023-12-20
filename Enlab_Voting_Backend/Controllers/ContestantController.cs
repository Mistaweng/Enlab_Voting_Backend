using Enlab_Voting_Backend.Model;
using Enlab_Voting_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enlab_Voting_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class ContestantController : ControllerBase
	{
		private readonly IContestantInterfaceRepo _contestantRepo;

		public ContestantController(IContestantInterfaceRepo contestantRepo)
		{
			_contestantRepo = contestantRepo;
		}

		[HttpPost("vote/{voterId}/{contestantId}")]
		public async Task<IActionResult> VoteForCandidate(string voterId, string contestantId)
		{
			var result = await _contestantRepo.VoteForCandidateAsync(voterId, contestantId);

			switch (result)
			{
				case 1:
					return Ok("Vote successful");
				case -1:
					return BadRequest("Voter has already voted for the candidate");
				default:
					return BadRequest("Vote failed");
			}
		}

		[HttpGet("vote-count/{contestantId}")]
		public async Task<IActionResult> GetVoteCount(string contestantId)
		{
			var voteCount = await _contestantRepo.GetVoteCountAsync(contestantId);

			return Ok(voteCount);
		}

		// Uncomment the following if you implement GetVoteHistoryAsync in IContestantInterfaceRepo
		// [HttpGet("vote-history/{contestantId}")]
		// public async Task<IActionResult> GetVoteHistory(string contestantId)
		// {
		//     var voteHistory = await _contestantRepo.GetVoteHistoryAsync(contestantId);
		//     return Ok(voteHistory);
		// }
	}


}
