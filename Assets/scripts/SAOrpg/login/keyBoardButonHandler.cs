using TMPro;
using UnityEngine;

namespace SAOrpg.Login
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
            checker = gameObject.GetComponent<collisionChecker>();
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

            //if (checker.entered){
                //testClick = false;
                //master.addText(textValue);

            //}

            if (checker.entered && textValue == "backspace" && checker.collidedObject.Contains("finger"))
            {
                master.removeText(1);
                testClick = false;
            }
            else if (checker.entered && textValue.Contains("shift") && !master.isShifted && checker.collidedObject.Contains("finger"))
            {
                master.isShifted = true;
                testClick = false;
            } 
            else if (checker.entered && textValue.Contains("shift") && master.isShifted && checker.collidedObject.Contains("finger"))
            {
                master.isShifted = false;
                testClick = false;
            }
            else if (checker.entered && textValue == "space" && checker.collidedObject.Contains("finger"))
            {
                master.addText(" ");
                testClick = false;
            }
            else if (checker.entered  && textValue == "copy" && checker.collidedObject.Contains("finger"))
            {
                master.CopiesString = master.currentText.text;
                testClick = false;
            }
            else if (checker.entered && textValue == "paste" && checker.collidedObject.Contains("finger"))
            {
                master.addText(master.CopiesString);
                testClick = false;
            }
            else if (checker.entered && textValue == "enter" && checker.collidedObject.Contains("finger"))
            {
                master.preformAction();
                testClick = false;
            }
            else if (checker.entered && checker.collidedObject.Contains("finger"))
            {
                testClick = false;
                master.addText(textValue);
            }
        }
    }
}
