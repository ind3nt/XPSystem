using System;
using Exiled.API.Features;
using XPSystem.Configs;
using XPSystem.Events;
using Player = XPSystem.Events.Player;

namespace XPSystem
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "sky3z";

        public override string Name => "XPSystem";

        public override string Prefix => "XPSystem";

        public override Version Version => base.Version;

        public static Plugin Instance;

        public static InitDB InitDB;

        public static XPSystem XPSystem;

        public static Player Player;

        public static Usergroups Usergroups;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            InitDB = new InitDB();
            Usergroups = new Usergroups();
            XPSystem = new XPSystem();

            InitDB.Init();

            Exiled.Events.Handlers.Player.Verified += PlayerJoin.OnPlayerVerifed;
            Exiled.Events.Handlers.Player.Dying += KillEvents.OnKill;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel += WarheadInteract.OnInteracted;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Instance = null;
            InitDB = null;
            Usergroups = null;
            XPSystem = null;

            Exiled.Events.Handlers.Player.Verified -= PlayerJoin.OnPlayerVerifed;
            Exiled.Events.Handlers.Player.Dying -= KillEvents.OnKill;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel -= WarheadInteract.OnInteracted;
        }
    }
}
