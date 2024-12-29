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

            if (Level > Plugin.Instance.Config.LevelNames.Count() || Level <= 0)
            {
                response = "Введите корректный уровень!";
                return false;
            }

            if (playerId == 1 || playerId == 0)
            {
                response = $"Введите кооректный ID!";
                return false;
            }

            var target = Player.List.FirstOrDefault(player => player.Id == playerId);

            if (target is null)
            {
                response = $"Игрок с id {playerId} не найден";
                return false;
            }

            XPSystem.SetLvl(target, Level);

            response = $"Вы установили игроку {target.Nickname} - {Level} Уровень!";
            return true;
        }
    }
}
