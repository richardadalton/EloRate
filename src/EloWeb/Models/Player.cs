using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Player
    {
        private LinkedList<int> _ratings;

        public string Name { get; set; }
        public int Rating { get { return _ratings.First.Value; } }

        public int MaxRating { get { return _ratings.Max(); } }
        public int MinRating { get { return _ratings.Min(); } }



        public void AddRating(int rating)
        {
            if(_ratings == null)
                _ratings = new LinkedList<int>();

            _ratings.AddFirst(rating);
        }

        public void ChangeRating(int points)
        {
            _ratings.AddFirst(Rating + points);
        }

        public void DecreaseRating(int points)
        {
            _ratings.AddFirst(Rating - points);
        }

        public static Player CreateInitial(string name)
        {
            var player = new Player {Name = name};
            player.AddRating(1000);
            return player;
        }
    }
}