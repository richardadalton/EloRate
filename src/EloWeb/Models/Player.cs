using System;
using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Player
    {
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

        public string Form
        {
            get
            {
                return String.Concat(WinsAndLosses(Games.GamesByPlayer(Name))
                    .Reverse()
                    .Take(5));
            }
        }

        public int LongestWinningStreak
        {
            get
            {
                var results = WinsAndLosses(Games.GamesByPlayer(Name));
                return FindBestWinningStreak(results);
            }
        }

        private object WorL(Game game)
        {
            return game.Winner == Name ? "W" : "L";
        }

        public IEnumerable<IGrouping<String, Game>> MostWinsAgainst
        {
            get
            {
                return Games.GamesByPlayer(Name)
                   .Where(game => game.Winner == Name)
                   .GroupBy(game => game.Loser)
                   .OrderByDescending(group => group.Count());   
            }
            
        }

        public IEnumerable<IGrouping<String, Game>> MostLossesTo
        {
            get
            {
                return Games.GamesByPlayer(Name)
                   .Where(game => game.Loser == Name)
                   .GroupBy(game => game.Winner)
                   .OrderByDescending(group => group.Count());                   
            }            
        }

        private string WinsAndLosses(IEnumerable<Game> games)
        {
            var results = games
                .Where(g => g.Winner == Name || g.Loser == Name)
                .Select(WorL);
            return string.Join("", results);            
        }

        private int FindBestWinningStreak(string results)
        {
            var start = results.IndexOf('W');
            if (start == -1) return 0;

            var end = results.IndexOf('L', start);
            if (end == -1) return results.Length - start;

            var bestSoFar = end - start;
            var bestOfRest = FindBestWinningStreak(results.Substring(end));

            return bestSoFar > bestOfRest ? bestSoFar : bestOfRest;
        }


        public int WinRate
        {
            get
            {
                var games = Games.GamesByPlayer(Name).ToList();

                var total = games.Count;
                var wins = games.Count(g => g.Winner == Name);

                if (wins == 0 || total == 0) return 0;

                return (int)((decimal)wins/total*100);   
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
            _ratings.AddFirst(Rating + points);
        }

        public void DecreaseRating(int points)
        {
            _ratings.AddFirst(Rating - points);
        }
    }
}