using System;
using System.Linq;
using Exiled.API.Features;
using CommandSystem;
using XPSystem.Events;
using System.Collections.Generic;
using Player = XPSystem.Events.Player;

namespace XPSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class GetLeaderboardCommand : ICommand
    {
        public string Command => "getleaderboard";

        public string[] Aliases { get; } = { };

        public string Description => "Получить таблицу лидеров по уровню";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Exiled.API.Features.Player player = Exiled.API.Features.Player.Get(sender);

            var AllPlayers = InitDB.ReadAllFromDB();

            IEnumerable<Player> leaderboard = AllPlayers.OrderByDescending(x => x.Level);

            int i = 0;

            string message = null;

            foreach (Player item in leaderboard)
            {
                i++;
                message = message + $"#{i} | SteamID: {item.SteamId} | Уровень: {item.Level}\n";

                
                if (i == 10)
                    continue;
            }

            response = message;
            return true;
        }
    }
}
