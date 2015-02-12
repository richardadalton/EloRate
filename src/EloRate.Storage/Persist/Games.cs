using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Collections.Generic;
using EloRate.Storage.Model;

namespace EloRate.Storage.Persist
{
    public class Games
    {
        public static IEnumerable<Game> Load()
        {
            var table = GetTable("games");
            TableQuery<Game> query = new TableQuery<Game>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "kobopool"));
            return table.ExecuteQuery(query);
        }

        public static void PersistGame(Game game)
        {
            // TODO: Write to Storage table
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