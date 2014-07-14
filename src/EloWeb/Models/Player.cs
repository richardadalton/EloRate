using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Player
    {
        public const int InitialRating = 1000;

        private readonly LinkedList<int> _ratings = new LinkedList<int>();

        public string Name { get; set; }

        public int Rating
        {
            get
            {
                if(!_ratings.Any()) 
                    return 0;

                return _ratings.First.Value;
            }
        }

        public int MaxRating
        {
            get
            {
                if (!_ratings.Any())
                    return 0;
                
                return _ratings.Max();
            }
        }

        public int MinRating
        {
            get
            {
                if (!_ratings.Any())
                    return 0;

                return _ratings.Min();
            }
        }

        public int RatingChange
        {
            get
            {
                if (!_ratings.Any())
                    return 0;

                if (_ratings.First.Next == null)
                    return _ratings.First.Value;

                return _ratings.First.Value - _ratings.First.Next.Value;
            }
        }

        public void AddRating(int rating)
        {
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
            player.AddRating(InitialRating);
            return player;
        }
    }
}