using System;

namespace EloWeb.Models
{
    public class Game
    {
        public string Winner { get; set; }
        public string Loser { get; set; }

        public static Game Create(string game)
        {
            var simplify = game.Replace(" bt ", ">");
            var players = simplify.Split('>');
            return new Game { Winner = players[0], Loser = players[1] };
        }

        public override string ToString()
        {
            return String.Format("{0} bt {1}", Winner, Loser);
        }
    }
}