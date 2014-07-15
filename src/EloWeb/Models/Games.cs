using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace EloWeb.Models
{
    public class Games
    {
        private static readonly List<Game> _games = new List<Game>();

        public static void Initialise(IEnumerable<string> games)
        {
            games.ForEach(game => _games.Add(Game.Create(game)));
        }

        public static IEnumerable<Game> All()
        {
            return _games;
        }

        public static void Add(Game game)
        {
            _games.Add(game);
        }
    }
}