using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.DbAccess;


namespace DataAccess.Data
{
    public class ImagesData : IImagesData
    {
        private readonly ISqlDataAccess _db;

        public ImagesData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<ImageData>> GetAllImages() =>
            _db.LoadData<ImageData, dynamic>(storedProcedure: "dbo.ImagesDbGetAll", new { });

        public async Task<CountRecords?> Count()
        {
            var results = await _db.LoadData<CountRecords, dynamic>(storedProcedure: "dbo.ImagesDbCount", new { });
            return results.FirstOrDefault();
        }

        public async Task<GetMaxId?> GetMaxId()
        {
            var results = await _db.LoadData<GetMaxId, dynamic>(storedProcedure: "dbo.ImagesDbMaxId", new { });
            return results.FirstOrDefault();
        }

        public async Task<ImageData?> GetImageById(int id)
        {
            var results = await _db.LoadData<ImageData, dynamic>(storedProcedure: "dbo.ImagesDbGetById", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertNewImage(ImageData imgData)
        {
            //Below: Fixed some problem with 2nd Id.... Works now, better solution later...
            int id2 = imgData.Id;
            return _db.SaveData("dbo.ImagesDbInsert", new { imgData.Id, imgData.Title, imgData.Description, imgData.Rating, imgData.Image, id2 });
        }

        public Task UpdateImage(ImageData imgData) => _db.SaveData("dbo.ImagesDbUpdate", imgData);

        public Task DeleteImage(int id) => _db.SaveData("dbo.ImagesDbDelete", new { Id = id });

    }
}
