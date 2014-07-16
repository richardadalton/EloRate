using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace EloWeb.Models
{
    public class Games
    {
        private static readonly List<Game> _games = new List<Game>();

        public static void Initialise(IEnumerable<string> games)
        {
            games.ForEach(game => Add(Game.Create(game)));
        }

        public static IEnumerable<Game> All()
        {
            return _games.AsEnumerable();
        }

        public static IEnumerable<Game> MostRecent(int howMany)
        {
            return _games.AsEnumerable()
                .Reverse()
                .Take(howMany);
        }

        public static void Add(Game game)
        {
            _games.Add(game);
        }

        public static IEnumerable<Game> GamesByPlayer(string name)
        {
            return _games.Where(game => game.Winner == name || game.Loser == name);
        }
    }
}