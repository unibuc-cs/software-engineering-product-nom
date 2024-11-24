using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models
{
    public class Movie : BaseEntity
    {
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
