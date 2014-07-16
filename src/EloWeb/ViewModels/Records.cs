using System;
using System.Collections.Generic;
using System.Linq;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class Records
    {
        public IEnumerable<Player> CurrentTopRanked { get { return GetRecordHolders(p => p.Rating); } }
        public IEnumerable<Player> MostRatingsPointsEver { get { return GetRecordHolders(p => p.MaxRating); } }
        public IEnumerable<Player> BestWinRate { get { return GetRecordHolders(p => p.WinRate); } }
        public IEnumerable<Player> LongestWinningStreak { get { return GetRecordHolders(p => p.LongestWinningStreak); } }
        public IEnumerable<Player> CurrentWinningStreak { get { return GetRecordHolders(p => p.CurrentWinningStreak); } }

        private IEnumerable<Player> GetRecordHolders(Func<Player, int> criteria)
        {
            var sorted = Players.All().OrderByDescending(criteria);
            var record = criteria(sorted.First());

            return sorted.TakeWhile(p => criteria(p) == record);
        }
    }
}