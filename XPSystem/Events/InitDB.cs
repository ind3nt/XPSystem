using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace XPSystem.Events
{
    public class InitDB
    {
        static string DBFilePath {  get; set; }

        public static void Init()
        {
            string fileDBName = "players.txt";
            string fileFolder = Path.GetTempPath();
            DBFilePath = fileFolder + fileDBName;

            if (!File.Exists(DBFilePath))
            {
                var file = File.Create(DBFilePath);
                file.Close();
            }
        }

        public static void SaveToDB(Player player)
        {
            List<Player> allPlayers = ReadAllFromDB();
            allPlayers.Add(player);

            string serializedPlayers = JsonConvert.SerializeObject(allPlayers);

            File.WriteAllText(DBFilePath, serializedPlayers);
        }

        public static void SaveToDB(List<Player> players)
        {
            string serializedPlayers = JsonConvert.SerializeObject(players);

            File.WriteAllText(DBFilePath, serializedPlayers);
        }

        public static List<Player> ReadAllFromDB()
        {
            string json = File.ReadAllText(DBFilePath);

            List<Player> allPlayers = JsonConvert.DeserializeObject<List<Player>>(json);

            return allPlayers ?? new List<Player>();
        }

        public static void DeleteFromDB(string SteamID)
        {
            List<Player> allPlayers = ReadAllFromDB();
            
            Player playerForDelete = allPlayers.FirstOrDefault(p => p.SteamId == SteamID);

            if (playerForDelete != null)
            {
                allPlayers.Remove(playerForDelete);
                SaveToDB(allPlayers);
            }
        }
    }

    public class Player
    {
        public string SteamId { get; set; }

        public int Level { get; set; }

        public int XP { get; set; }

        public string NickName { get; set; }

        public Player(string SteamID, int Level, int XP, string NickName) 
        {
            this.SteamId = SteamID;
            this.Level = Level;
            this.XP = XP;
            this.NickName = NickName;
        }
    }
}
