using Enlab_Voting_Backend.Dtos;
using Enlab_Voting_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enlab_Voting_Backend.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class SignUpController : ControllerBase
	{
		private readonly IAppUserRepository _userRepository;

		public SignUpController(IAppUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpPost("register")]
		public async Task<IActionResult> CreateUser([FromBody] SignUpDto userRequest)
		{
			var res = await _userRepository.CreateUser(userRequest);
			if (res.Succeeded) return Ok(res);

			return BadRequest(res);
		}
	}
}
