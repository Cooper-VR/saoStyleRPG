using TMPro;
using UnityEngine;

namespace SAOrpg.keyBoard
{
    public class keyBoardMaster : MonoBehaviour
    {
        public string CopiesString;

        public GameObject textPrefab;
        public TMP_Text currentText;
        public bool isShifted = false;

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
    }
}
