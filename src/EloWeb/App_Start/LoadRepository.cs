using EloWeb.Controllers;
using EloWeb.Models;
using EloWeb.Repositories;

namespace EloWeb
{
    public class LoadRepository
    {
        public static void Load(string path)
        {
            Players.Initialise(PlayerData.Load(path));
            GameData.Load(path);
        }
    }
}