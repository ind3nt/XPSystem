using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace XPSystem
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public Dictionary<string, string> LevelNames { get; set; } = new Dictionary<string, string>()
        {
            { "1", "LVL 1 | Лох" },
            { "2", "LVL 2 | Не лох" },
            { "3", "LVL 2 | Что-то знает" },
            { "4", "LVL 4 | Знает чуть больше" },
            { "5", "LVL 5 | Сигма" },
            { "6", "LVL 6 | Пикми" },
            { "7", "LVL 7 | Фимоз" },
            { "8", "LVL 8 | Сосал" },
            { "9", "LVL 9 | Художник" },
            { "10", "LVL 10 | Босс художки" },
        };

        public int XpToLvlUp { get; set; } = 1000;

        public int XpFromKillSCP { get; set; } = 100;

        public int XpFromKillEnemy { get; set; } = 50;

        public int XpFromActivateWarhead { get; set; } = 200;
    }
}