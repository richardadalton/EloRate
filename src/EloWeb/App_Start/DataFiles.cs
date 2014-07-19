using EloWeb.Models;
using EloWeb.Persist;

namespace EloWeb
{
    public class DataFiles
    {
        public static void Connect(string path)
        {
            var gamesFile = path + "Games.txt";
            Games.Initialise(GamesData.Load(gamesFile));

            var playersFile = path + "Players.txt";
            Players.Initialise(PlayersData.Load(playersFile)); 
        }
    }
}