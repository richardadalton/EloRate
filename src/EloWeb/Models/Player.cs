using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EloClient.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Rating { get; set; }

        public static Player CreateInitial(string name)
        {
            return new Player { Name = name, Rating = 1000 };
        }

        public static Player Create(string name, int rating)
        {
            return new Player { Name = name, Rating = rating };
        }
    }
}