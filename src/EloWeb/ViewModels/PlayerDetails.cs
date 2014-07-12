
using System;
using System.Collections.Generic;
using System.Linq;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class PlayerDetails
    {
        public string Name { get; private set; }
        public int Rating { get; private set; }
        public IEnumerable<Game> GamesWon { get; private set; }
        public IEnumerable<Game> GamesLost { get; private set; }
        public string Form { get; private set; }

        public IEnumerable<IGrouping<String, Game>> MostWinsAgainst { get; private set; }
        public IEnumerable<IGrouping<String, Game>> MostLossesTo { get; private set; }

        public PlayerDetails(Player player, IEnumerable<Game> games)
        {
            Name = player.Name;
            Rating = player.Rating;

            var recent = games
                .Where(g => g.Winner == Name || g.Loser == Name)
                .Reverse()
                .Take(5)
                .Select(WOrL)
                .Reverse();
            Form = string.Join("-", recent);
                
            GamesWon = games.Where(g => g.Winner == Name);
            GamesLost = games.Where(g => g.Loser == Name);
            MostWinsAgainst = GamesWon.GroupBy(game => game.Loser).OrderByDescending(group => group.Count());
            MostLossesTo = GamesLost.GroupBy(game => game.Winner).OrderByDescending(group => group.Count());
        }

        private object WOrL(Game game)
        {
            return game.Winner == Name ? "W" : "L";
        }
    }
}