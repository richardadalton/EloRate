using System.Collections.Generic;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class Records
    {
        public IEnumerable<PlayerEntity> CurrentTopRanked { get; set; }
        public IEnumerable<PlayerEntity> MostRatingsPointsEver { get; set; }
        public IEnumerable<PlayerEntity> BestWinRate { get; set; }
        public IEnumerable<PlayerEntity> LongestWinningStreak { get; set; }
        public IEnumerable<PlayerEntity> CurrentWinningStreak { get; set; }
        public IEnumerable<PlayerEntity> LongestLosingStreak { get; set; }
        public IEnumerable<PlayerEntity> CurrentLosingStreak { get; set; }
    }
}