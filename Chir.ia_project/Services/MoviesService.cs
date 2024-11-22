namespace Chir.ia_project.Services
{
    public interface IMoviesService
    {
        public string GetName(Guid Id);
    }

    public class MoviesService
    {
        public string GetName(Guid Id)
        {
            return "name";
        }
    }
}
