using Exiled.Events.EventArgs.Warhead;

namespace XPSystem.Events
{
    public class WarheadInteract
    {
        public static void OnStartWarhead(StartingEventArgs ev)
        {
            if (ev.Player == null) 
                return;

            XPSystem.AddXP(ev.Player, Plugin.Instance.Config.XpFromActivateWarhead);
            ev.Player.Broadcast(2, $"Вы получили {Plugin.Instance.Config.XpFromActivateWarhead} XP за активацию боеголовки!", Broadcast.BroadcastFlags.Normal, true);
        }
    }
}
