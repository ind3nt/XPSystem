using System;
using System.Linq;
using Exiled.API.Features;
using CommandSystem;

namespace XPSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RemoveXPCommand : ICommand
    {
        public string Command => "removexp";

        public string[] Aliases { get; } = { };

        public string Description => "Отнять опыт у игрока";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 2)
            {
                response = "Использование: removexp <id игрока> <количество опыта>";
                return false;
            }

            int.TryParse(arguments.First(), out var playerId);
            int.TryParse(arguments.ElementAt(1), out int XP);

            var player = Player.List.FirstOrDefault(p => p.Id == playerId);

            if (player is null)
            {
                response = $"Игрок с id {playerId} не найден";
                return false;
            }

            XPSystem.RemoveXP(player, XP);

            response = $"Вы отняли у игрока {player.Nickname} - {XP} единиц опыта!";
            return true;
        }
    }
}
