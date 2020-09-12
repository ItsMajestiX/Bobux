using CommandSystem;
using RemoteAdmin;
using System;

namespace Bobux.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class AddBobux : ICommand
    {
        public string Command { get; } = "addbobux";

        public string[] Aliases { get; } = { "bobuxadd" };

        public string Description { get; } = "Gives the specified player the specified amount of bobux.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "addbobux";
            return true;
        }
    }
}
