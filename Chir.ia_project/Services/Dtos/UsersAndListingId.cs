namespace Chir.ia_project.Services.Dtos
{
    public class UsersAndListingId
    {
        public Guid ListingId {  get; set; }
        public List<UserIdAndName> Users { get; set; } = new();
    }
}
