using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EloClient.Models
{
    class EloCalc
    {
        private const int VOLATILITY = 50;

        public static int CalculateNewRating(int rating, int opponentRating, int score)
        {
            var expected = (decimal)rating / (rating + opponentRating);
            return (Int32)Math.Round((rating + VOLATILITY * (score - expected)), MidpointRounding.AwayFromZero);
        }
    }
}