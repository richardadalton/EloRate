using System.Linq;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class Records
    {
        public Player CurrentTopRanked { get; private set; }
        public Player MostRatingsPointsEver { get; private set; }
        public Player BestWinRate { get; private set; }

        public Records()
        {
            CurrentTopRanked = Players.All().OrderByDescending(p => p.Rating).First();
            MostRatingsPointsEver = Players.All().OrderByDescending(p => p.MaxRating).First();
            BestWinRate = Players.All().OrderByDescending(p => p.WinRate).First();
        }
    }
}