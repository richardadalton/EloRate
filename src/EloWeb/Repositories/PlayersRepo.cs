using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EloWeb.Models;

namespace EloWeb.Repositories
{
    public partial class RatingsRepo
    {
        private static Dictionary<String, Player> _players;
        private const string PlayersFile = "Players.txt";

        public static Dictionary<String, Player> LoadPlayers()
        {
            try
            {
                using (var file = new StreamReader(_path + PlayersFile))
                {
                    return LoadPlayers(file);
                }
            }
            catch (FileNotFoundException)
            {
                return new Dictionary<string, Player>();
            }
        }

        public static Dictionary<string, Player> LoadPlayers(StreamReader file)
        {
            var players = new Dictionary<String, Player>();
            string line;

            while ((line = file.ReadLine()) != null)
                players.Add(line, Player.CreateInitial(line));

            return players;
        }

        public static void AddPlayer(string name)
        {
            _players.Add(name, Player.CreateInitial(name));
            WritePlayerToFile(name);
        }

        private static void WritePlayerToFile(string name)
        {
            File.AppendAllText(_path + PlayersFile, name + "\n");
        }

        public static Dictionary<String, Player> Players()
        {
            return _players;
        }

        public static Player PlayerByName(string name)
        {
            return _players[name];
        }

        public static IEnumerable<String> PlayerNames()
        {
            return _players.Values.Select(p => p.Name);
        }


    }
}