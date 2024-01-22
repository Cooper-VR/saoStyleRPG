using SAOrpg.playerAPI.RPGsstuff.stats;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace SAOrpg
{
    public static class saveSystem
    {
        public static void SavePlayer(playerStats player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + $"/{player.UserName}.rsu";
            FileStream stream = new FileStream(path, FileMode.Create);

            saveData data = new saveData(player);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static saveData LoadPlayer(string userName, string password)
        {
            //first: loop tough all files ending in .rsu

            string[] rsuFiles = Directory.GetFiles(Application.persistentDataPath);

            Debug.Log(Application.persistentDataPath);

            // Loop through the files
            for (int i = 0; i < rsuFiles.Length; i++)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream steam = new FileStream(rsuFiles[0], FileMode.Open);

                saveData data = formatter.Deserialize(steam) as saveData;

                if (userName == data.UserName && password == playerStats.Decrypt(data.password))
                {
                    Debug.Log("found");
                    return data;
                }
                else
                {
                    Debug.Log("this file is wrong");
                }

                steam.Close();
            }
            Debug.LogError("save file not found");
            return null;

            //check the userName and password for each
            //if good, then return the data
            //if not, continue to the next
            //if loop ends then return null

            
        }
    }
}
