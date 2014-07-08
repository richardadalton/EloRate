using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EloClient.Models
{
    public class Game
    {
        public string Winner { get; private set; }
        public string Loser { get; private set; }

        public static Game Create(string game)
        {
            var simplify = game.Replace(" bt ", ">");
            var players = simplify.Split('>');
            return new Game { Winner = players[0], Loser = players[1] };
        }
    }
}