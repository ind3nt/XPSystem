using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPSystem.Configs
{
    public class Usergroups
    {
        public static UserGroup Level_1 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level1Name,
            BadgeColor = "Crimson",
        };

        public static UserGroup Level_2 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level2Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_3 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level3Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_4 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level4Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_5 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level5Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_6 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level6Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_7 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level7Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_8 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level8Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_9 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level9Name,
            BadgeColor = "Crimson"
        };

        public static UserGroup Level_10 { get; set; } = new UserGroup()
        {
            BadgeText = Plugin.Instance.Config.Level10Name,
            BadgeColor = "Crimson"
        };

    }
}
