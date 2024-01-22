using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using TMPro;
using UnityEngine;

namespace SAOrpg.Login
{
    public class keyBoardMaster : MonoBehaviour
    {
        public string CopiesString;
        public bool createAcount;
        public GameObject textPrefab;
        public TMP_Text currentText;
        public bool isShifted = false;
        public playerStats stats;

        public TMP_Text displayName;
        public TMP_Text userName;
        public TMP_Text password;

        public void addText(string text)
        {
            string currentString = currentText.text;

            currentText.text = currentString + text;
        }
        public void removeText(int length)
        {
            string currentString = currentText.text;

            string newString = "";

            for (int i = 0; i < currentString.Length - length; i++) 
            {
                newString += currentString[i];
            }

            currentText.text = newString;
        }
        public void preformAction()
        {

            if (createAcount)
            {
                stats.UserName = userName.text;
                stats.Password = password.text;
                stats.displayName = displayName.text;

                stats.transform.position = new Vector3(0, 100, 0);

                stats.savePlayer();
            }
            else
            {

                stats.UserName = userName.text;
                stats.Password = password.text;

                stats.loadPlayer();
            }
            
        }
    }
}
