using Bobux.Database;
using Bobux.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobux
{
    class Util
    {
        public static Exiled.API.Features.Player PlayerExists(ArraySegment<string> args, out ArraySegment<string> otherArgs)
        {
            ArraySegment<string> tempOut = new ArraySegment<string> { };
            Exiled.API.Features.Player tempRet = null;
            int k = 0;
            string s = "";
            args.ToList().ForEach((i) =>
            {
                k++;
                s += i;
                foreach (Exiled.API.Features.Player player in Exiled.API.Features.Player.List)
                {
                    if (player.Nickname == s || player.RawUserId == s || player.DisplayNickname == s)
                    {
                        tempOut = args.Segment(k);
                        tempRet = player;
                        break;
                    }
                }
            });
            if (tempRet != null)
            {
                otherArgs = tempOut;
                return tempRet;
            }
            else
            {
                otherArgs = new ArraySegment<string> { };
                return tempRet;
            }
        }

        public static User GetUser(ArraySegment<string> arguments, BobuxContext db)
        {
            Exiled.API.Features.Player player = Util.PlayerExists(arguments, out arguments);
            if (player != null)
            {
                Exiled.API.Enums.AuthenticationType auth = player.AuthenticationType;
                if (auth == Exiled.API.Enums.AuthenticationType.Discord)
                {
                    try
                    {
                        User idk = db.Users.Single(u => u.DiscordId == UInt64.Parse(player.RawUserId));
                        idk.Player = player;
                        return idk;
                    }
                    catch
                    {
                        User idk = db.Add(new User { SteamId = null, DiscordId = UInt64.Parse(player.RawUserId), Bobux = 0, TotalBobux = 0 }).Entity;
                        idk.Player = player;
                        return idk;
                    }
                }
                else if (auth == Exiled.API.Enums.AuthenticationType.Steam)
                {
                    try
                    {
                        User idk = db.Users.Single(u => u.SteamId == UInt64.Parse(player.RawUserId));
                        idk.Player = player;
                        return idk;
                    }
                    catch
                    {
                        User idk = db.Add(new User { SteamId = UInt64.Parse(player.RawUserId), DiscordId = null, Bobux = 0, TotalBobux = 0 }).Entity;
                        idk.Player = player;
                        return idk;
                    }
                }
                throw new BadAuthException("The player found is using an unsupported auth type. The only types currently supported are Steam and Discord auth");
            }
            throw new PlayerNotFoundException("A player matching the arguments given was not found");
        }
    }
}
