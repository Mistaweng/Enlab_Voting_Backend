namespace Enlab_Voting_Backend.Services
{
	public interface IFileUploadRepository
	{
		Task<string> UploadImageToCloudinaryAndSave(IFormFile file);
	}
}
