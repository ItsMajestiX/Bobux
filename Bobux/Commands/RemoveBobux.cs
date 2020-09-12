using CommandSystem;
using RemoteAdmin;
using System;

namespace Bobux.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class RemoveBobux : ICommand
    {
        public string Command { get; } = "removebobux";

        public string[] Aliases { get; } = { "bobuxremove" };

        public string Description { get; } = "Takes the specified amount of bobux away from the specified player.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "removebobux";
            return true;
        }
    }
}
