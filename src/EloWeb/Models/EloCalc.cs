using System;

namespace EloWeb.Models
{
    class EloCalc
    {
        private const int Volatility = 50;

        public static int CalculateNewRating(int rating, int opponentRating, int score)
        {
            var expected = (decimal)rating / (rating + opponentRating);
            return (Int32)Math.Round((rating + Volatility * (score - expected)), MidpointRounding.AwayFromZero);
        }
    }
}