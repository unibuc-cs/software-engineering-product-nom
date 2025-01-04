namespace Chir.ia_project.Models.Entities
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public byte[] ContentBytes { get; set; }
        public string ContentType { get; set; }

        public Guid EntityId { get; set; } // id of the other associated entity
    }
}
