using EloWeb.Repositories;

namespace EloClient.App_Start
{
    public class LoadRepository
    {
        public static void Load(string path)
        {
            RatingsRepo.Load(path);
        }
    }
}