using System;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace EloWeb.Models
{
    public class Players
    {
        private static Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public static void Initialise(IEnumerable<string> names)
        {
           names.ForEach(name => _players.Add(name, Player.CreateInitial(name)));
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