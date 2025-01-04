using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Chir.ia_project.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Chir.ia_project.Services
{
    public interface IImageService
    {
        Task UploadImagesAsync(ImageRequest request);
    }

    public class ImageService : ServiceBase, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        public async Task UploadImagesAsync(ImageRequest request)
        {
            foreach (var image in request.ImageFiles)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);

                    UnitOfWork.Image.Add(new Image()
                    {
                        Name = image.Name,
                        ContentBytes = memoryStream.ToArray(),
                        ContentType = image.ContentType,
                        EntityId = request.EntityId
                    });
                }
            }

            await UnitOfWork.SaveChangesAsync();
        }
    }

}
