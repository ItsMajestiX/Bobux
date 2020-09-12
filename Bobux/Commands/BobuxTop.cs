using CommandSystem;
using RemoteAdmin;
using System;

namespace Bobux.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class BobuxTop : IUserCommand
    {
        public string Command { get; } = "bobuxtop";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "Shows the top bobux owners on this server. Specify a page to see more.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "bobuxtop";
            return true;
        }
    }
}
