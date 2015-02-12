using Microsoft.WindowsAzure.Storage.Table;

namespace EloRate.Storage.Model
{
    public class PlayerEntity : TableEntity
    {
        public PlayerEntity()
        {
        }

        public PlayerEntity(string account, string name, bool isRetired)
        {
            Account = account;
            Name = name;
            IsRetired = isRetired;
            PartitionKey = account;
            RowKey = name;
        }

        public string Account { get; set; }
        public string Name { get; set; }
        public bool IsRetired { get; set; }
    }
}