using EloWeb.Models;
using EloWeb.Persist;
using System.IO;

namespace EloWeb
{
    public class RestoreModelFromDisk
    {
        public static void Load(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var gamesFile = path + "Games.txt";
            var playersFile = path + "Players.txt";

            Players.Initialise(PlayersData.Load(playersFile), GamesData.Load(gamesFile)); 
        }
    }
}