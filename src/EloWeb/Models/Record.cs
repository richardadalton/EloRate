using System;
using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Record
    {
        public static IEnumerable<Player> GetRecordHolders(Func<Player, int> criteria)
        {
            var sorted = Players.All().OrderByDescending(criteria);
            var record = criteria(sorted.First());
            return sorted.TakeWhile(p => criteria(p) == record);
        }
    }
}