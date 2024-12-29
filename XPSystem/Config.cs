using Exiled.API.Interfaces;

namespace XPSystem
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public string Level1Name { get; set; } = "LVL 1 | Лох";

        public string Level2Name { get; set; } = "LVL 2 | Не лох";

        public string Level3Name { get; set; } = "LVL 3 | Что то знает";

        public string Level4Name { get; set; } = "LVL 4 | Знает чуть больше";

        public string Level5Name { get; set; } = "LVL 5 | Сигма";

        public string Level6Name { get; set; } = "LVL 6 | Пикми";

        public string Level7Name { get; set; } = "LVL 7 | Фимоз";

        public string Level8Name { get; set; } = "LVL 8 | Сосал";

        public string Level9Name { get; set; } = "LVL 9 | Художник";

        public string Level10Name { get; set; } = "LVL 10 | Босс художки";

        public int XpToLvlUp { get; set; } = 1000;

        public int XpFromKillSCP { get; set; } = 100;

        public int XpFromKillEnemy { get; set; } = 50;

        public int XpFromActivateWarhead { get; set; } = 200;
    }
}