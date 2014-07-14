using System.Collections.Generic;
using System.IO;
using EloWeb.Models;

namespace EloWeb.Repositories
{
    public partial class RatingsRepo
    {
        private static List<Game> _games;
        private const string GamesFile = "Games.txt";

        public static List<Game> LoadGames()
        {
            try
            {
                using (var file = new StreamReader(_path + GamesFile))
                {
                    return LoadGames(file);
                }
            }
            catch (FileNotFoundException)
            {
                return new List<Game>();
            }
        }

        public static List<Game> LoadGames(StreamReader file)
        {
            var games = new List<Game>();
            string line;

            while ((line = file.ReadLine()) != null)
                games.Add(Game.Create(line));

            return games;
        }

        public static void AddGame(Game game)
        {
            _games.Add(game);
            WriteGameToFile(game);
            RateGame(game);
        }

        private static void WriteGameToFile(Game game)
        {
            File.AppendAllText(_path + GamesFile, game + "\n");
        }

        public static List<Game> Games()
        {
            return _games;
        }
    }
}