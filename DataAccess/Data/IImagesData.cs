using DataAccess.Models;

namespace DataAccess.Data
{
	public interface IImagesData
	{
		
		Task<IEnumerable<ImageData>> GetAllImages();

		Task<ImageData?> GetImageById(int id);

        Task<CountRecords> Count();

        Task<GetMaxId> GetMaxId();

        Task InsertNewImage(ImageData imageData);

        Task UpdateImage(ImageData imageData);

        Task DeleteImage(int id);
    }


}