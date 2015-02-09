using System;
using Microsoft.WindowsAzure.Storage.Table;
namespace EloWeb.Models
{
    public class Game : TableEntity
    {
        public string Winner { get; set; }
        public string Loser { get; set; }
    }
}