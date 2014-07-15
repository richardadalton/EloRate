using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class Records
    {
        public IEnumerable<Player> CurrentTopRanked { get; private set; }
        public IEnumerable<Player> MostRatingsPointsEver { get; private set; }
        public IEnumerable<Player> BestWinRate { get; private set; }
        public IEnumerable<Player> LongestWinningStreak { get; private set; }
        public IEnumerable<Player> CurrentWinningStreak { get; private set; }

        public Records()
        {
            CurrentTopRanked = GetCurrentTopRanked();
            MostRatingsPointsEver = GetAllTimeRatingPoints();
            BestWinRate = GetBestWinRate();
            LongestWinningStreak = GetLongestWinningStreak();
            CurrentWinningStreak = GetCurrentWinningStreak();
        }

        private IEnumerable<Player> GetCurrentTopRanked()
        {
            var sorted = Players.All().OrderByDescending(p => p.Rating);
            var record = sorted.First().Rating;

            return sorted.TakeWhile(p => p.Rating == record);
        }

        private IEnumerable<Player> GetAllTimeRatingPoints()
        {
            var sorted = Players.All().OrderByDescending(p => p.MaxRating);
            var record = sorted.First().MaxRating;

            return sorted.TakeWhile(p => p.MaxRating == record);
        }

        private IEnumerable<Player> GetBestWinRate()
        {
            var sorted = Players.All().OrderByDescending(p => p.WinRate);
            var record = sorted.First().WinRate;

            return sorted.TakeWhile(p => p.WinRate == record);
        }

        private IEnumerable<Player> GetLongestWinningStreak()
        {
            var sorted = Players.All().OrderByDescending(p => p.LongestWinningStreak);
            var record = sorted.First().LongestWinningStreak;

            return sorted.TakeWhile(p => p.LongestWinningStreak == record);
        }

        private IEnumerable<Player> GetCurrentWinningStreak()
        {
            var sorted = Players.All().OrderByDescending(p => p.CurrentWinningStreak);
            var record = sorted.First().CurrentWinningStreak;

            return sorted.TakeWhile(p => p.CurrentWinningStreak == record);
        }
    }
}