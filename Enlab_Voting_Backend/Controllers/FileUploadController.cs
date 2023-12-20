using Enlab_Voting_Backend.Dtos;
using Enlab_Voting_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enlab_Voting_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileUploadController : ControllerBase
	{

		private readonly IFileUploadRepository _fileUploadRepository;

		public FileUploadController(IFileUploadRepository fileUploadRepository)
		{
			_fileUploadRepository = fileUploadRepository;
		}
		[HttpPost("image/FIle-upload")]
		public async Task<IActionResult> UploadImageOrFile(IFormFile file)
		{
			var uploadedImage = await _fileUploadRepository.UploadImageToCloudinaryAndSave(file);

			if (uploadedImage == null)
			{
				return NotFound(ApiResponse.Failed(uploadedImage));
			}
			return Ok(ApiResponse.Success(uploadedImage));
		}
	}
}
