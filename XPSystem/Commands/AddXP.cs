using System;
using System.Linq;
using Exiled.API.Features;
using CommandSystem;

namespace XPSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class AddXPCommand : ICommand
    {
        public string Command => "addxpp";

        public string[] Aliases { get; } = { };

        public string Description => "Добавить опыт игроку";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 2)
            {
                response = "Использование: addxp <id игрока> <количество опыта>";
                return false;
            }

            int.TryParse(arguments.First(), out var playerId);
            int.TryParse(arguments.ElementAt(1), out int XP);

            if (playerId == 1 || playerId == 0)
            {
                response = $"Введите кооректный ID!";
                return false;
            }

            if ( XP <= 0 )
            {
                response = $"Введите корректное количество опыта!";
                return false;
            }

            var target = Player.List.FirstOrDefault(player => player.Id == playerId);

            if (target is null)
            {
                response = $"Игрок с id {playerId} не найден";
                return false;
            }

            XPSystem.AddXP(target, XP);

            response = $"Вы добавили игроку {target.Nickname} - {XP} единиц опыта!";
            return true;
        }
    }
}
