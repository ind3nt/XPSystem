using System.Linq;
using XPSystem.Configs;
using XPSystem.Events;

namespace XPSystem
{
    public class XPSystem
    {
        public Player player;

        public static void AddXP(Exiled.API.Features.Player Player, int xp)
        {
            var player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player == null)
                return;

            if (player.XP + xp >= (Plugin.Instance.Config.XpToLvlUp * player.Level))
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
            var player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            Player newData = new Player(Player.RawUserId, player.Level + 1, 0, Player.Nickname);

            InitDB.DeleteFromDB(Player.RawUserId);
            InitDB.SaveToDB(newData);

            Player.Broadcast(2, $"Ваш новый уровень: {newData.Level}!", Broadcast.BroadcastFlags.Normal, true);
            AddToScoreboard(Player, newData.Level);
        }

        public static void SetLvl (Exiled.API.Features.Player Player, int Level)
        {
            var player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

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
            var player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

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
            var player = InitDB.ReadAllFromDB().FirstOrDefault(p => p.SteamId == Player.RawUserId);

            if (player == null)
                return null;

            return $"{player.XP} / {(Plugin.Instance.Config.XpToLvlUp * player.Level)}";
        }

        public static void AddToScoreboard(Exiled.API.Features.Player player, int Level)
        {
            switch (Level)
            {
                case 1:
                    player.RankName = Usergroups.Level_1.BadgeText;
                    break;

                case 2:
                    player.RankName = Usergroups.Level_2.BadgeText;
                    break;

                case 3:
                    player.RankName = Usergroups.Level_3.BadgeText;
                    break;

                case 4:
                    player.RankName = Usergroups.Level_4.BadgeText;
                    break;

                case 5:
                    player.RankName = Usergroups.Level_5.BadgeText;
                    break;

                case 6:
                    player.RankName = Usergroups.Level_6.BadgeText;
                    break;

                case 7:
                    player.RankName = Usergroups.Level_7.BadgeText;
                    break;

                case 8:
                    player.RankName = Usergroups.Level_8.BadgeText;
                    break;

                case 9:
                    player.RankName = Usergroups.Level_9.BadgeText;
                    break;

                case 10:
                    player.RankName = Usergroups.Level_10.BadgeText;
                    break;
            }
        }
    }
}
