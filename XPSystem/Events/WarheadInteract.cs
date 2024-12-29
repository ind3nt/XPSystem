using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Player;

namespace XPSystem.Events
{
    public class WarheadInteract
    {
        public static void OnInteracted(ActivatingWarheadPanelEventArgs ev)
        {
            if (ev.Player == null) 
                return;

            XPSystem.AddXP(ev.Player, Plugin.Instance.Config.XpFromActivateWarhead);
            ev.Player.Broadcast(5, $"Вы получили {Plugin.Instance.Config.XpFromActivateWarhead} XP за активацию боеголовки!");
        }
    }
}
