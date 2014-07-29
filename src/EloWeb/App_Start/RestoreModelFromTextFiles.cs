using EloWeb.Models;
using EloWeb.Persist;
using System.IO;

namespace EloWeb
{
    public class RestoreModelFromTextFiles
    {
        public static void Load(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var gamesFile = path + "Games.txt";
            Games.Initialise(GamesData.Load(gamesFile)); 

            var playersFile = path + "Players.txt";
            Players.Initialise(PlayersData.Load(playersFile));

            var retiredPlayersFile = path + "RetiredPlayers.txt";
            RetiredPlayers.Initialise(RetiredPlayersData.Load(retiredPlayersFile));
        }
    }
}