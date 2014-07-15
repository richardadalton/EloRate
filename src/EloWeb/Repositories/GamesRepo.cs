using System.Collections.Generic;
using System.IO;
using System.Linq;
using EloWeb.Models;

namespace EloWeb.Repositories
{
    public class GameData
    {
        private const string GamesFile = "Games.txt";
        
        public static IEnumerable<string> Load(string path)
        {
            try
            {
                return File.ReadLines(path + GamesFile);
            }
            catch (FileNotFoundException)
            {
                return new List<string>().AsEnumerable();
            }
        }

        private static void WriteGameToFile(Game game)
        {
            //File.AppendAllText(_path + GamesFile, game + "\n");
        }
    }
}