using CommandSystem;
using RemoteAdmin;
using System;

namespace Bobux.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class GetBobux : IUserCommand
    {
        public string Command { get; } = "getbobux";

        public string[] Aliases { get; } = { "bobuxget" };

        public string Description { get; } = "Gets the amount of bobux the specified player has.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "getbobux";
            return true;
        }
    }
}
