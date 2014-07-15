using EloWeb.Models;
using EloWeb.Persist;

namespace EloWeb
{
    public class RestoreModelFromDisk
    {
        public static void Load(string path)
        {
            var playersFile = path + "Players.txt";
            var gamesFile = path + "Games.txt";

            Players.Initialise(PlayersData.Load(playersFile), GamesData.Load(gamesFile)); 
        }
    }
}