using EloWeb.Repositories;

namespace EloWeb
{
    public class LoadRepository
    {
        public static void Load(string path)
        {
            RatingsRepo.Load(path);
        }
    }
}