using System;
using Exiled.API.Features;
using XPSystem.Events;

namespace XPSystem
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "sky3z";

        public override string Name => "XPSystem";

        public override string Prefix => "XPSystem";

        public override Version Version => base.Version;

        public static Plugin Instance;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            
            InitDB.Init();

            Exiled.Events.Handlers.Player.Verified += PlayerJoin.OnPlayerVerifed;
            Exiled.Events.Handlers.Player.Dying += KillEvents.OnKill;
            Exiled.Events.Handlers.Warhead.Starting += WarheadInteract.OnStartWarhead;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Instance = null;

            Exiled.Events.Handlers.Player.Verified -= PlayerJoin.OnPlayerVerifed;
            Exiled.Events.Handlers.Player.Dying -= KillEvents.OnKill;
            Exiled.Events.Handlers.Warhead.Starting -= WarheadInteract.OnStartWarhead;
        }
    }
}
