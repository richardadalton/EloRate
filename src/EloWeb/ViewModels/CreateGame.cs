using System;
using System.Collections.Generic;
using EloWeb.Models;

namespace EloWeb.ViewModels
{
    public class CreateGame
    {
        public IEnumerable<Game> RecentGames { get; set; }
        public IEnumerable<String> Players { get; set; }
        public String Winner { get; set; }
        public String Loser { get; set; }
    }
}