using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Services.Dtos
{
    public class ImageRequest
    {
        [Required] 
        [Display(Name = "File")] 
        public List<IFormFile> ImageFiles { get; set; } = new();

        [Required]
        public Guid EntityId { get; set; }
    }
}
