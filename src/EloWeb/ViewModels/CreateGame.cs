using System;
using System.Collections.Generic;

namespace EloWeb.ViewModels
{
    public class CreateGame
    {
        public List<String> Players { get; set; }
        public String Winner { get; set; }
        public String Loser { get; set; }
    }
}