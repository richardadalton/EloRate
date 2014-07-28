using System;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace EloWeb.Models
{
    public class RetiredPlayers
    {
        private static readonly List<String> _retiredPlayers = new List<String>();

        public static void Initialise(IEnumerable<string> names)
        {
            names.ForEach(name => _retiredPlayers.Add(name));
        }

        public static bool IsRetired(string name)
        {
            return _retiredPlayers.Contains(name);
        }
    }
}