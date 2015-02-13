using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EloWeb.Persist;
using EloWeb.Models;

namespace EloWeb
{
    public class RestoreModelFromTableStorage
    {
        public static void Load()
        {
            Games.Initialise(GamesData.Load()); 
            Players.Initialise(PlayersData.Load());            
        }
    }
}