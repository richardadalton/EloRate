using System;

namespace EloWeb.Models
{
    class EloCalc
    {
        private const int Volatility = 50;

        public static int PointsExchanged(int winnerRating, int loserRating)
        {
            var expected = (decimal)winnerRating / (winnerRating + loserRating);
            return (Int32)Math.Round((Volatility * (1 - expected)), MidpointRounding.AwayFromZero);
        }

    }
}