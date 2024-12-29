using System;
using System.Linq;
using CommandSystem;
using XPSystem.Events;
using System.Collections.Generic;
using Player = XPSystem.Events.Player;

namespace XPSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class GetLeaderboardCommand : ICommand
    {
        public string Command => "getleaderboard";

        public string[] Aliases { get; } = { };

        public string Description => "Получить таблицу лидеров по уровню";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            int i = 0;
            string message = null;

            var AllPlayers = InitDB.ReadAllFromDB();

            Exiled.API.Features.Player player = Exiled.API.Features.Player.Get(sender);

            IEnumerable<Player> leaderboard = AllPlayers.OrderByDescending(x => x.Level);

            foreach (Player item in leaderboard)
            {
                i++;
                message += $"\n#{i} | {item.NickName} | SteamID: {item.SteamId} | Уровень: {item.Level} | Опыт: {item.XP}";

                if (i == 10)
                    continue;
            }
            response = message;
            return true;
        }
    }
}
