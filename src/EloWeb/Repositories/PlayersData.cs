using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EloWeb.Repositories
{
    public class PlayersData
    {
        private const string PlayersFile = "Players.txt";

        public static IEnumerable<string> Load(string path)
        {
            try
            {
                return File.ReadLines(path + PlayersFile);
            }
            catch (FileNotFoundException)
            {
                return new List<string>().AsEnumerable();
            }
        }


        //public static IEnumerable<string> LoadPlayers(StreamReader file)
        //{
        //    var players = new Dictionary<String, Player>();
        //    string line;

        //    while ((line = file.ReadLine()) != null)
        //        players.Add(line, Player.CreateInitial(line));

        //    return players;
        //}

        //public static void AddPlayer(string name)
        //{
        //    _players.Add(name, Player.CreateInitial(name));
        //    WritePlayerToFile(name);
        //}

        //private static void WritePlayerToFile(string name)
        //{
        //    File.AppendAllText(_path + PlayersFile, name + "\n");
        //}
    }
}