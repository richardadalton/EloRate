using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Games
    {
        private static IEnumerable<string> _games;

        public static void Initialise(IEnumerable<string> games)
        {
            _games = games;
        }

        public static IEnumerable<Game> All()
        {
            return _games.Select(Game.FromString).AsEnumerable();
        }

        public static IEnumerable<Game> MostRecent(int howMany)
        {
            return All()
                .Reverse()
                .Take(howMany);
        }

        public static IEnumerable<Game> GamesByPlayer(string name)
        {
            return All().Where(game => game.Winner == name || game.Loser == name);
        }
    }
}