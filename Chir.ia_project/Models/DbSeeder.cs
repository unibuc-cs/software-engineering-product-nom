using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models
{
    public interface IDbSeeder
    {
        void Seed();
    }

    public class DbSeeder
    {
        private readonly Context _context;

        public DbSeeder(Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddStuff();
        }


        private void AddStuff()
        {

            //aici adaugam chestii
            //de ex:
            /*
             _context.Users.Add(new AppUser()))
             */
        }
    }
}
