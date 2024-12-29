using System;
using Exiled.API.Features;
using CommandSystem;

namespace XPSystem.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class GetMyXPCommand : ICommand
    {
        public string Command => "getmyxp";

        public string[] Aliases { get; } = { };

        public string Description => "Узнать свой опыт";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            response = $"Ваш опыт: {XPSystem.GetXP(player)}";
            return true;
        }
    }
}
