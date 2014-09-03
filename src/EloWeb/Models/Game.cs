using System;

namespace EloWeb.Models
{
    public class Game
    {
        private const string BEAT = "beat";
 
        public string Winner { get; set; }
        public string Loser { get; set; }
        
        public static Game FromString(string game)
        {
            var splitOn = new[] { BEAT };
            var players = game.Split(splitOn, StringSplitOptions.None);
            return new Game { Winner = players[0].Trim(), Loser = players[1].Trim() };
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Winner, BEAT ,Loser);
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