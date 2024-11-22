using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Chir.ia_project.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
