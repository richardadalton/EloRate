using System;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace EloWeb.Models
{
    public class Players
    {
        private static Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public static void Initialise(IEnumerable<String> names, IEnumerable<String> games)
        {
           names.ForEach(name => _players.Add(name, Player.CreateInitial(name)));
           
           Games.Initialise(games);           
           Games.All().ForEach(UpdateRatings);            
        }

        public static void UpdateRatings(Game game)
        {
            var winner = PlayerByName(game.Winner);
            var loser = PlayerByName(game.Loser);

            var pointsExchanged = EloCalc.PointsExchanged(winner.Rating, loser.Rating);

            winner.IncreaseRating(pointsExchanged);
            loser.DecreaseRating(pointsExchanged);
        }

        public static IEnumerable<Player> All()
        {
            return _players.Values;
        }

        public static IEnumerable<String> Names()
        {
            return _players.Keys;
        }

        public static Player PlayerByName(string name)
        {
            return _players[name];
        }
    }
}