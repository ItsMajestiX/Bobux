using Bobux.Database;
using CommandSystem;
using RemoteAdmin;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Bobux.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class SetBobux : ICommand
    {
        public string Command { get; } = "setbobux";

        public string[] Aliases { get; } = { "bobuxset" };

        public string Description { get; } = "Sets the specified player's bobux to the specified amount.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            try
            {
                User user;
                using (var db = new BobuxContext())
                {
                    /*user = Util.GetUser(arguments, db);
                    user.Bobux = int.Parse(arguments.Last());
                    user.TotalBobux = user.TotalBobux - user.Bobux + int.Parse(arguments.Last());
                    db.SaveChanges();*/
                }
                Exiled.API.Features.Log.Info(sender.LogName + " gave " + user.Player.Nickname + " " + int.Parse(arguments.Last()) + " bobux.");
                response = "Set " + user.Player.Nickname + "'s bobux to " + int.Parse(arguments.Last()) + " bobux.";
                return true;
            }
            catch (Exception e)
            {
                response = e.Message;
                return false;
            }
        }
    }
}
