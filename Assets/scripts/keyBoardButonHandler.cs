using SAOrpg.playerAPI;
using TMPro;
using UnityEngine;

namespace SAOrpg.keyBoard
{
    public class keyBoardButonHandler : MonoBehaviour
    {
        string textValue = "";
        collisionChecker checker;
        public keyBoardMaster master;
        public bool testClick;

        TMP_Text textPrefab;

        // Start is called before the first frame update
        void Start()
        {
            checker = new collisionChecker();
            textPrefab = Instantiate(master.textPrefab, transform).GetComponent<TMP_Text>();

            textValue = gameObject.name.Split('/')[0];
        }


        // Update is called once per frame
        void Update()
        {
            textPrefab.text = textValue;

            if (master.isShifted)
            {
                try
                {
                    textValue = gameObject.name.Split('/')[1];
                }
                catch
                {
                    Debug.Log("spacial/not named key");
                }
                
            }
            else
            {
                textValue = gameObject.name.Split("/")[0];
            }
            
            if (gameObject.name == "/?" && master.isShifted)
            {
                textValue = "?";
            } 
            else if (gameObject.name == "/?")
            {
                textValue = "/";
            }

            if ((checker.entered || testClick) && textValue == "backspace")
            {
                master.removeText(1);
                testClick = false;
            }
            else if ((checker.entered || testClick) && textValue.Contains("shift") && !master.isShifted)
            {
                master.isShifted = true;
                testClick = false;
            } 
            else if ((checker.entered || testClick) && textValue.Contains("shift") && master.isShifted)
            {
                master.isShifted = false;
                testClick = false;
            }
            else if ((checker.entered || testClick) && textValue == "space")
            {
                master.addText(" ");
                testClick = false;
            }
            else if ((checker.entered || testClick) && textValue == "copy")
            {
                master.CopiesString = master.currentText.text;
                testClick = false;
            }
            else if ((checker.entered || testClick) && textValue == "paste")
            {
                master.addText(master.CopiesString);
                testClick = false;
            }
            else if (checker.entered || testClick)
            {
                testClick = false;
                master.addText(textValue);
            }
        }
    }
}
