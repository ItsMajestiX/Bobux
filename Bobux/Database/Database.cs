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
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=" + Bobux.Instance.Config.DBPath);
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public UInt64? SteamId { get; set; }
        public UInt64? DiscordId { get; set; }
        public int Bobux { get; set; }
        public int TotalBobux { get; set; }
    }
}