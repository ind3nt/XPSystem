using System.Linq;
using Exiled.Events.EventArgs.Player;


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
                Player newPlayer = new Player(ev.Player.RawUserId, 1, 0, ev.Player.Nickname);
                InitDB.SaveToDB(newPlayer);
               
                XPSystem.AddToScoreboard(ev.Player, 1);

                return;
            }
            
            XPSystem.AddToScoreboard(ev.Player, player.Level);
        }
    }
}
