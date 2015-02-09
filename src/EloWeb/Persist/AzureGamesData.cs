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
            TableQuery<Game> query = new TableQuery<Game>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "kobopool"));
            return table.ExecuteQuery(query);
        }

        public static void Persist(Game game)
        {
            // TODO: Write to Storage table
        }

        public static void Delete(String Id)
        {
            var table = GetTable("games");
            var game = Games.All().Where(g => g.PartitionKey == "kobopool" && g.RowKey == Id).First();
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