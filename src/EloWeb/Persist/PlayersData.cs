using EloWeb.Models;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Collections.Generic;

namespace EloWeb.Persist
{
    public class PlayersData
    {
        private static string account;

        static PlayersData()
        {
            account = ConfigurationManager.AppSettings["Account"];
        }

        public static IEnumerable<PlayerEntity> Load()
        {
            var table = GetTable("players");
            TableQuery<PlayerEntity> query = new TableQuery<PlayerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, account));
            return table.ExecuteQuery(query);
        }

        public static void PersistPlayer(Player player)
        {
            var playerEntity = new PlayerEntity(account, player.Name, player.IsRetired);
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