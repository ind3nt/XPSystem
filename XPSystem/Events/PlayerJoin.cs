using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using XPSystem.Configs;

namespace XPSystem.Events
{
    public class PlayerJoin
    {

        public static void OnPlayerVerifed(VerifiedEventArgs ev)
        {
            string SteamID = ev.Player.RawUserId;
            var player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == SteamID);

            if (player == null)
            {
                Player newPlayer = new Player(ev.Player.RawUserId, 1, 0);
                InitDB.SaveToDB(newPlayer);
                Log.Info("Add to DB");
               
                XPSystem.AddToScoreboard(ev.Player, 1);

                return;
            }
            
            XPSystem.AddToScoreboard(ev.Player, player.Level);
        }
    }
}
