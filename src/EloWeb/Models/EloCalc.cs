using System;

namespace EloWeb.Models
{
    class EloCalc
    {
        private const int Volatility = 50;

        public static int PointsExchanged(int winnerRating, int loserRating)
        {
            var difference = (double)loserRating - winnerRating;
            var expected = 1 / (1 + (Math.Pow(10,(difference/400))));
            
            var exchanged = (Int32)Math.Round((Volatility * (1 - expected)), MidpointRounding.AwayFromZero);
            return exchanged;
        }
    }
}