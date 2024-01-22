using SAOrpg.playerAPI.RPGstuff.Movement;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using SAOrpg.Login;

namespace SAOrpg.playerAPI.RPGstuff.StatsInventory
{
    public class playerStats : MonoBehaviour
    {

        private const string key = "AAECAwQFBgcICQoLDA0ODw=="; // Replace with a strong, unique key
        private const string iv = "WZ2eS4LmjQa9+Z2b"; // Replace with a strong, unique IV

        public string displayName;
        public string UserName;
        public string Password;

        public int level;
        public float maxDamageSpeed;
        public int maxHealth;
        public float health;
        public float dashInterval;

        public int EXP;
        public int nextLevelEXP;

        public int col;

        public int levelPoints;

        public levelingObject[] skills;

        public inventoryObjects[] weapons;
        public inventoryObjects[] items;

        public void incrementLevel()
        {
            level++;
            levelPoints++;

            maxHealth = Mathf.RoundToInt(Mathf.Pow(1.104f, level) + 249);
        }

        public void incrementEXP(int increaseAmount)
        {
            EXP += increaseAmount;

            while (EXP >= nextLevelEXP)
            {
                EXP -= nextLevelEXP;

                nextLevelEXP += 50;

                incrementLevel();
            }
        }

        public void usePoint(levelingObject skill)
        {
            if (levelPoints > 0)
            {
                skill.incrementLevel();
                levelPoints--;
            }
        }

        public string Encrypt(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string encryptedPassword)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public void savePlayer()
        {
            saveSystem.SavePlayer(this);
        }

        public void loadPlayer()
        {
            saveData data = saveSystem.LoadPlayer(UserName, Password);

            if (data == null)
            {
                //do method to make them make an acount

                //just return
                return;
            }

            level = data.level;
            maxHealth = data.maxHealth;
            health = data.health;
            EXP = data.EXP;
            dashInterval = data.dashInterval;
            nextLevelEXP = data.nextLevelEXP;
            levelPoints = data.levelPoints;
            displayName = data.displayName;
            UserName = data.UserName;
            Password = Decrypt(data.password);
            
            weapons = new inventoryObjects[data.weaponNames.Length];
            items = new inventoryObjects[data.itemNames.Length];

            for (int i = 0; i < data.SkillEXP.Length; i++)
            {
                skills[i].skillType = data.SkillskillType[i];
                skills[i].level = data.Skilllevel[i];
                skills[i].nextLevelEXP = data.SkillnextLevelEXP[i];
                skills[i].EXP = data.SkillEXP[i];
            }

            for (int i = 0; i < data.weaponNames.Length; i++)
            {
                weapons[i] = (inventoryObjects)AssetDatabase.LoadAssetAtPath(data.weaponNames[i], typeof(inventoryObjects));
            }
            for (int i = 0; i < data.itemNames.Length; i++)
            {
                items[i] = (inventoryObjects)AssetDatabase.LoadAssetAtPath(data.itemNames[i], typeof(inventoryObjects));
            }


            Vector3 position = new Vector3();

            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

            try
            {
                GetComponent<playerMovement>().enabled = false;

                transform.position = position;

                GetComponent<playerMovement>().enabled = true;
            } catch (Exception e)
            {
                Debug.LogError("youre not supposed to call this method");
            }

            
        }
    }
}

