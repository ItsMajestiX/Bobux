using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandSystem;
using RemoteAdmin;

namespace Bobux.Commands
{
    class ExiledPlayerCast : ICommandSender
    {
        private static string _logName = "";
        private static Exiled.API.Features.Player _player;
        public string LogName => _logName;

        public ExiledPlayerCast(Exiled.API.Features.Player player)
        {
            _player = player;
            _logName = player.Nickname + " (" + player.UserId + ")";
        }

        public void Respond(string message, bool success = true)
        {
            _player.SendConsoleMessage(_player, message, "white");
        }
    }

    class UserCommandHandler
    {
        //https://stackoverflow.com/a/949285/10720080
        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
                assembly.GetTypes()
                  .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                  .ToArray();
        }

        private static List<string> GetCapitalizations(string[] s)
        {
            List<string> q = new List<string> { };
            foreach (string l in s)
            {
                List<string> g = new List<string> { l };
                for (int i = 0; i < s.Length; i++)
                {
                    List<string> j = new List<string> { };
                    foreach (string k in g)
                    {
                        j.Add(k.Substring(0, i) + k.Substring(i, 1).ToLower() + k.Substring(Math.Min(i + 1, s.Length - 1), k.Length - (i + 1)));
                        j.Add(k.Substring(0, i) + k.Substring(i, 1).ToUpper() + k.Substring(Math.Min(i + 1, s.Length - 1), k.Length - (i + 1)));
                    }
                    g = j;
                }
                q = q.Concat(g).ToList();
            }
            return q;
        }

        internal static void OnSendingConsoleCommand(SendingConsoleCommandEventArgs ev)
        {
            Exiled.API.Features.Log.Debug("foo");
            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Bobux.Commands");
            foreach (Type i in typelist)
            {
                if (typeof(ICommand).IsAssignableFrom(i))
                {
                    Exiled.API.Features.Log.Debug(i.Name);
                    ConstructorInfo m = i.GetConstructor(Type.EmptyTypes);
                    //too lazy to properly check for interfaces
                    if (m != null)
                    {
                        ICommand j = m.Invoke(new object[] { }) as ICommand;
                        Exiled.API.Features.Log.Debug("baz");
                        if (GetCapitalizations(new List<string> { j.Command }.Concat(j.Aliases).ToArray()).Contains(ev.Name))
                        {
                            if (j is IUserCommand)
                            {
                                string executeOut = "";
                                j.Execute(new ArraySegment<string>(ev.Arguments.ToArray()), new ExiledPlayerCast(ev.Player), out executeOut);
                                ev.ReturnMessage = executeOut;
                                //ev.Player.SendConsoleMessage(executeOut, "white");
                                ev.Allow = false;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
