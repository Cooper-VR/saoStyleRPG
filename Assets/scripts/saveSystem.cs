using SAOrpg.playerAPI.RPGsstuff.stats;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SAOrpg
{
    public static class saveSystem
    {
        public static void SavePlayer(playerStats player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "player.rsu";
            FileStream stream = new FileStream(path, FileMode.Create);

            saveData data = new saveData(player);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static saveData LoadPlayer()
        {
            string path = Application.persistentDataPath + "player.rsu";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream steam = new FileStream(path, FileMode.Open);

                saveData data = formatter.Deserialize(steam) as saveData;

                steam.Close();

                return data;
            }
            else
            {
                Debug.LogError("save file not found");
                return null;
            }
        }
    }
}
