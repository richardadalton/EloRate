using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EloWeb.Models
{
    public class PlayerRating
    {
        private readonly LinkedList<int> _ratings = new LinkedList<int>();
        public const int InitialRating = 1000;

        public static PlayerRating CreateInitial()
        {
            var rating = new PlayerRating();
            rating.AddRating(InitialRating);
            return rating;
        }

        public int Value
        {
            get
            {
                if (!_ratings.Any())
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

        public void IncreaseRating(int points)
        {
            _ratings.AddFirst(Value + points);
        }

        public void DecreaseRating(int points)
        {
            _ratings.AddFirst(Value - points);
        }

    }
}