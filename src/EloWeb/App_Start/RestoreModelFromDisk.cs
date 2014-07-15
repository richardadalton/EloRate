using EloWeb.Models;
using EloWeb.Repositories;

namespace EloWeb
{
    public class RestoreModelFromDisk
    {
        public static void Load(string path)
        {
            Players.Initialise(PlayersData.Load(path), GamesData.Load(path)); 
        }
    }
}