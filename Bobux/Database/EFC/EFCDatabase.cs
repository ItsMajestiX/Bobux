/*using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobux.Database
{
    public class BobuxContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            //=> options.UseSqlite("Data Source=" + Bobux.Instance.Config.DBPath);
            => options.UseSqlite(CreateInMemoryDatabase());

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public UInt64? SteamId { get; set; }
        public UInt64? DiscordId { get; set; }
        public int Bobux { get; set; }
        public int TotalBobux { get; set; }

        [NotMapped] 
        public Exiled.API.Features.Player Player { get; set; }
    }
}*/