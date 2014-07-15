
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
        public int MaxRating { get; private set; }
        public int MinRating { get; private set; }
        public string Form { get; private set; }
        public IEnumerable<IGrouping<String, Game>> MostWinsAgainst { get; private set; }
        public IEnumerable<IGrouping<String, Game>> MostLossesTo { get; private set; }

        public PlayerDetails(Player player, IEnumerable<Game> games)
        {
            Name = player.Name;
            Rating = player.Rating;
            MaxRating = player.MaxRating;
            MinRating = player.MinRating;

            var recent = games
                .Where(g => g.Winner == Name || g.Loser == Name)
                .Reverse()
                .Take(5)
                .Select(WorL)
                .Reverse();
            Form = string.Join("-", recent);

            MostWinsAgainst = games
                .Where(game => game.Winner == Name)
                .GroupBy(game => game.Loser)
                .OrderByDescending(group => group.Count());
                                   
            MostLossesTo = games
                .Where(game => game.Loser == Name)
                .GroupBy(game => game.Winner)
                .OrderByDescending(group => group.Count());
        }

        private object WorL(Game game)
        {
            return game.Winner == Name ? "W" : "L";
        }
    }
}