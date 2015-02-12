using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Collections.Generic;
using EloRate.Storage.Model;

namespace EloRate.Storage.Persist
{
    public class Players
    {
        public static IEnumerable<PlayerEntity> Load()
        {
            var table = GetTable("players");
            TableQuery<PlayerEntity> query = new TableQuery<PlayerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "kobopool"));
            return table.ExecuteQuery(query);
        }

        public static void CreatePlayer(string name)
        {
            var playerEntity = new PlayerEntity("kobopool", name, false);
            var table = GetTable("players");
            WritePlayer(table, playerEntity);
        }

        static void WritePlayer(CloudTable table, PlayerEntity player)
        {
            TableOperation insertOp = TableOperation.Insert(player);
            table.Execute(insertOp);
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