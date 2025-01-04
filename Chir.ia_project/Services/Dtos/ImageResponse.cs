namespace Chir.ia_project.Services.Dtos
{
    public class ImageResponse
    {
        public Guid Id { get; set; }
        public string ContentType { get; set; }
        public byte[] ContentBytes { get; set; }
    }
}
