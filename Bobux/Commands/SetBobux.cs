using Bobux.Database;
using CommandSystem;
using RemoteAdmin;
using System;
using System.Linq;
using System.Collections.Generic;

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
            using (var db = new BobuxContext())
            {
                User user = Util.GetUser(arguments, db);
                user.Bobux = int.Parse(arguments.Last());
                user.TotalBobux = user.TotalBobux - user.Bobux + int.Parse(arguments.Last());
            }
            response = "";
            return true;
        }
    }
}
