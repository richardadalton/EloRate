using System.Collections.Generic;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class Records
    {
        public IEnumerable<Player> CurrentTopRanked { get; set; }
        public IEnumerable<Player> MostRatingsPointsEver { get; set; }
        public IEnumerable<Player> BestWinRate { get; set; }
        public IEnumerable<Player> LongestWinningStreak { get; set; }
        public IEnumerable<Player> CurrentWinningStreak { get; set; }
        public IEnumerable<Player> LongestLosingStreak { get; set; }
        public IEnumerable<Player> CurrentLosingStreak { get; set; }
    }
}