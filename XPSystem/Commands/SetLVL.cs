using System;
using System.Linq;
using Exiled.API.Features;
using CommandSystem;

namespace XPSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SetLVLCommand : ICommand
    {
        public string Command => "setlvl";

        public string[] Aliases { get; } = { };

        public string Description => "Изменить уровень игрока";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 2)
            {
                response = "Использование: setlvl <id игрока> <уровень>";
                return false;
            }

            int.TryParse(arguments.First(), out var playerId);
            int.TryParse(arguments.ElementAt(1), out int Level);

            var player = Player.List.FirstOrDefault(p => p.Id == playerId);

            if (player is null)
            {
                response = $"Игрок с id {playerId} не найден";
                return false;
            }

            XPSystem.SetLvl(player, Level);

            response = $"Вы установили игроку {player.Nickname} - {Level} Уровень!";
            return true;
        }
    }
}
