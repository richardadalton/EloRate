using EloClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EloClient.Repositories
{
    public class RatingsRepo
    {
        private static Dictionary<String, Player> _players;
        private static List<Game> _games;

        public static void Load(string path)
        {
            _games = LoadGames(path + "Games.txt"); 
            _players = LoadPlayers(path + "Players.txt");
            RefreshRatings();       
        }

        public static List<Game> LoadGames(string path)
        {
            var file = new StreamReader(path);
            return LoadGames(file);
        }

        public static List<Game> LoadGames(StreamReader file)
        {
            var games = new List<Game>();
            string line;

            while ((line = file.ReadLine()) != null)
                games.Add(Game.Create(line));

            return games;
        }

        public static Dictionary<String, Player> LoadPlayers(string path)
        {
            var file = new StreamReader(path);
            return LoadPlayers(file);
        }

        public static Dictionary<string, Player> LoadPlayers(StreamReader file)
        {
            var players = new Dictionary<String, Player>();
            string line;

            while ((line = file.ReadLine()) != null)
                players.Add(line, Player.CreateInitial(line));

            return players;
        }

        public static void RefreshRatings()
        {
            foreach (var game in _games)
            {
                var winner = _players[game.Winner];
                var loser = _players[game.Loser];
                winner.Rating = EloCalc.CalculateNewRating(winner.Rating, loser.Rating, 1);
                loser.Rating = EloCalc.CalculateNewRating(loser.Rating, loser.Rating, 0);
            }
        }


        public static List<Game> Games()
        {
            return _games;
        }

        public static Dictionary<String, Player> Players()
        {
            return _players;
        }

        public static Player PlayerByName(string name)
        {
            return _players[name];
        }

        public static IEnumerable<Player> Leaderboard()
        {
            return _players.Values.OrderByDescending(p => p.Rating);
        }
    }
}