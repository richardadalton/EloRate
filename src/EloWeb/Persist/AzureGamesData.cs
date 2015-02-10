using EloWeb.Models;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Collections.Generic;
using System;

namespace EloWeb.Persist
{
    public class AzureGamesData
    {
        public static IEnumerable<Game> Load()
        {
            var table = GetTable("games");
            TableQuery<Game> query = new TableQuery<Game>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, ConfigurationManager.AppSettings["Account"]));
            return table.ExecuteQuery(query);
        }

        public static void Persist(Game game)
        {
            game.PartitionKey = ConfigurationManager.AppSettings["Account"];
            game.RowKey = Guid.NewGuid().ToString();
            game.WhenPlayed = DateTime.Now;


            var table = GetTable("games");
            TableOperation insertOp = TableOperation.Insert(game);
            table.Execute(insertOp);
        }

        public static void Delete(String Id)
        {
            var table = GetTable("games");
            var game = Games.All().Where(g => g.PartitionKey == ConfigurationManager.AppSettings["Account"] && g.RowKey == Id).First();
            TableOperation deleteOp = TableOperation.Delete(game);
            table.Execute(deleteOp);
        }

        private static CloudTable GetTable(string tableName)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connStr);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }
    }
}