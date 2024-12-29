using System.Collections.Generic;
using System.Linq;
using XPSystem.Events;

namespace XPSystem
{
    class XPSystem
    {
        public static void AddXP(Exiled.API.Features.Player Player, int xp)
        {
            Player player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player == null)
                return;

            if (CheckLvlUp(player.XP, xp, player.Level))
            {
                LvlUp(Player);
                return;
            }

            int newXP = player.XP + xp;

            Player newData = new Player(Player.RawUserId, player.Level, newXP, player.NickName);

            InitDB.DeleteFromDB(Player.RawUserId);
            InitDB.SaveToDB(newData);
        }

        public static void LvlUp(Exiled.API.Features.Player Player)
        {
            Player player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player.Level == Plugin.Instance.Config.LevelNames.Count())
                return;

            Player newData = new Player(Player.RawUserId, player.Level + 1, 0, Player.Nickname);

            InitDB.DeleteFromDB(Player.RawUserId);
            InitDB.SaveToDB(newData);

            Player.Broadcast(2, $"Ваш новый уровень: {newData.Level}!", Broadcast.BroadcastFlags.Normal, true);
            AddToScoreboard(Player, newData.Level);
        }

        public static void SetLvl(Exiled.API.Features.Player Player, int Level)
        {
            Player player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player == null)
                return;

            Player newData = new Player(Player.RawUserId, Level, 0, Player.Nickname);

            InitDB.DeleteFromDB(Player.RawUserId);
            InitDB.SaveToDB(newData);

            AddToScoreboard(Player, newData.Level);

            return;
        }

        public static void RemoveXP(Exiled.API.Features.Player Player, int XP)
        {
            Player player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player == null)
                return;

            if (XP > player.XP)
                XP = player.XP;

            Player newData = new Player(Player.RawUserId, player.Level, player.XP - XP, player.NickName);

            InitDB.DeleteFromDB(Player.RawUserId);
            InitDB.SaveToDB(newData);

            return;
        }

        public static string GetXP(Exiled.API.Features.Player Player)
        {
            Player player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player == null)
                return null;

            return $"{player.XP} / {(Plugin.Instance.Config.XpToLvlUp * player.Level)}";
        }

        public static bool CheckLvlUp(int curXP, int newXP, int Level)
        {
            if ((curXP + newXP) >= (Plugin.Instance.Config.XpToLvlUp * Level))
                return true;

            return false;
        }

        public static void AddToScoreboard(Exiled.API.Features.Player player, int Level)
        {
            if (Plugin.Instance.Config.LevelNames.ContainsKey(Level.ToString()))
            {
                player.RankName = Plugin.Instance.Config.LevelNames[Level.ToString()];
            }
        }
    }
}
