using System;
using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Record
    {
        public static IEnumerable<PlayerEntity> GetRecordHolders(IEnumerable<PlayerEntity> players, Func<PlayerEntity, int> criteria)
        {
            var sorted = players.OrderByDescending(criteria);
            var record = criteria(sorted.First());
            return sorted.TakeWhile(p => criteria(p) == record);
        }
    }
}