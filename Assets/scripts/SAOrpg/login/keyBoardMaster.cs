using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using System.Collections;
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
        public Transform spawn;

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

                stats.transform.position = spawn.transform.position;
                Debug.Log(stats.transform.position);
                stats.savePlayer();
                StartCoroutine(ExampleCoroutine());
            }
            else
            {

                stats.UserName = userName.text;
                stats.Password = password.text;

                stats.loadPlayer();
            }
            
        }

        IEnumerator ExampleCoroutine()
        {
            //Print the time of when the function is first called.
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(2);

            //After we have waited 5 seconds print the time again.
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            stats.loadPlayer();
        }
    }
}
