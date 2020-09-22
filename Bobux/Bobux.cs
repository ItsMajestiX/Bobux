using Bobux.Commands;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.IO;

namespace Bobux
{

    public class Bobux:Plugin<Config>
    {
        private static readonly Lazy<Bobux> LazyInstance = new Lazy<Bobux>(() => new Bobux());
        public static Bobux Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Bobux()
        {

        }

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.SendingConsoleCommand += UserCommandHandler.OnSendingConsoleCommand;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.SendingConsoleCommand -= UserCommandHandler.OnSendingConsoleCommand;
            base.OnDisabled();
        }
    }
}
