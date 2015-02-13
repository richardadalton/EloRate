using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;
using System.Configuration;

namespace EloWeb.Models
{
    public class Players
    {
        private static Dictionary<string, PlayerEntity> _players = new Dictionary<string, PlayerEntity>();

        public static void Initialise(IEnumerable<PlayerEntity> playerEntities)
        {
            var account = ConfigurationManager.AppSettings["Account"];
            _players = playerEntities.Select(p => new PlayerEntity(account, p.Name, p.IsRetired)).ToDictionary(p => p.Name);
        }

        public static void Add(PlayerEntity player)
        {
            _players.Add(player.Name, player);
        }

        public static void UpdateRatings(Game game)
        {
            var winner = PlayerByName(game.Winner);
            var loser = PlayerByName(game.Loser);

            var pointsExchanged = EloCalc.PointsExchanged(winner.Rating.Value, loser.Rating.Value);

            winner.Rating.IncreaseRating(pointsExchanged);
            loser.Rating.DecreaseRating(pointsExchanged);
        }

        public static IEnumerable<PlayerEntity> All()
        {
            return _players.Values;
        }

        public static IEnumerable<PlayerEntity> Active()
        {
            return _players.Values.Where(p => !p.IsRetired);
        }

        public static IEnumerable<string> Names()
        {
            return _players.Keys;
        }

        public static PlayerEntity PlayerByName(string name)
        {
            if (!_players.ContainsKey(name))
                return new PlayerEntity();

            return _players[name];
        }
    }
}