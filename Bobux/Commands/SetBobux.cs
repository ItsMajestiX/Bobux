using CommandSystem;
using RemoteAdmin;
using System;

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
            response = "setbobux " + sender.LogName;
            return true;
        }
    }
}
