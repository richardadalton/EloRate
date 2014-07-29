using System;

namespace EloWeb.Models
{
    public class Game
    {
        public string Winner { get; set; }
        public string Loser { get; set; }

        private static readonly string[] BeatTokens = { " bt ", " beat " };
        private const int ActiveToken = 1;
        
        public static Game FromString(string game)
        {
            var players = game.Split(BeatTokens, StringSplitOptions.None);
            return new Game { Winner = players[0], Loser = players[1] };
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", Winner, BeatText(), Loser);
        }       

        public static string BeatText()
        {
            return BeatTokens[ActiveToken];
        }


        protected bool Equals(Game other)
        {
            return string.Equals(Winner, other.Winner) && string.Equals(Loser, other.Loser);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Winner != null ? Winner.GetHashCode() : 0) * 397) ^ (Loser != null ? Loser.GetHashCode() : 0);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Game) obj);
        }
    }
}