using System;
using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Record
    {
        public static IEnumerable<Player> GetRecordHolders(IEnumerable<Player> players, Func<Player, int> criteria)
        {
            var sorted = players.OrderByDescending(criteria);
            var record = criteria(sorted.First());
            return sorted.TakeWhile(p => criteria(p) == record);
        }
    }
}