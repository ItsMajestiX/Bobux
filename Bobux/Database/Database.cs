using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobux.Database
{
    public class BobuxContext : DbContext
    {
        private string _path;

        public BobuxContext(string path)
        {
            _path = path;
        }

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=" + _path);
    }

    public class User
    {
        public int SteamID { get; set; }
        public int DiscordID { get; set; }
        public int Bobux { get; set; }
        public int TotalBobux { get; set; }
    }
}

/*
using (var db = new BobuxContext(Bobux.Instance.Config.DBPath)) {}
*/
