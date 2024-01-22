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

            if (checker.entered && textValue == "backspace" && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                master.removeText(1);
                testClick = false;
            }
            else if (checker.entered && textValue.Contains("shift") && !master.isShifted && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                master.isShifted = true;
                testClick = false;
            } 
            else if (checker.entered && textValue.Contains("shift") && master.isShifted && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                master.isShifted = false;
                testClick = false;
            }
            else if (checker.entered && textValue == "space" && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                master.addText(" ");
                testClick = false;
            }
            else if (checker.entered  && textValue == "copy" && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                master.CopiesString = master.currentText.text;
                testClick = false;
            }
            else if (checker.entered && textValue == "paste" && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                master.addText(master.CopiesString);
                testClick = false;
            }
            else if (checker.entered && textValue == "enter" && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)") || testClick)
            {
                master.preformAction();
                testClick = false;
            }
            else if (checker.entered && (checker.collidedObject == "Controller (left)" || checker.collidedObject == "Controller (right)"))
            {
                testClick = false;
                master.addText(textValue);
            }
        }
    }
}
