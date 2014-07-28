using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace EloWeb.Models
{
    public class Players
    {
        public const int InitialRating = 1000;

        private static readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public static void Initialise(IEnumerable<string> names)
        {
           names.ForEach(name => Add(CreateInitial(name)));           
           Games.All().ForEach(UpdateRatings);            
        }


        public static void Add(Player player)
        {
            _players.Add(player.Name, player);
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

        public static IEnumerable<Player> Active()
        {
            return _players.Values.Where(p => !RetiredPlayers.IsRetired(p.Name));
        }

        public static IEnumerable<string> Names()
        {
            return _players.Keys;
        }

        public static Player PlayerByName(string name)
        {
            return _players[name];
        }

        public static Player CreateInitial(string name)
        {
            var player = new Player { Name = name };
            player.AddRating(InitialRating);
            return player;
        }
    }
}