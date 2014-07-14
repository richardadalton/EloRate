using System.IO;
using EloWeb.Models;

namespace EloWeb.Repositories
{
    public partial class RatingsRepo
    {
        private static string _path;
                    
        public static void Load(string path)
        {
            _path = path;

            if (!Directory.Exists(path))
                CreateNewDataFiles();

            _games = LoadGames(); 
            _players = LoadPlayers();
            RefreshRatings();       
        }

        private static void CreateNewDataFiles()
        {
            Directory.CreateDirectory(_path);
        }

        public static void RefreshRatings()
        {
            foreach (var game in _games)
                RateGame(game);
        }

        private static void RateGame(Game game)
        {
            var winner = _players[game.Winner];
            var loser = _players[game.Loser];

            var exchanged = EloCalc.PointsExchanged(winner.Rating, loser.Rating);
            winner.ChangeRating(exchanged);
            loser.ChangeRating(-exchanged);            
        }
    }
}