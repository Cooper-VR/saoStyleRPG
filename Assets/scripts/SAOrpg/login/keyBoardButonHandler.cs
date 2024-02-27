using TMPro;
using UnityEngine;

namespace SAOrpg.Login
{
    public class keyBoardButonHandler : MonoBehaviour
    {
        string textValue = "";
         public keyBoardMaster master;
        public bool testClick;

        TMP_Text textPrefab;

        // Start is called before the first frame update
        void Start()
        {
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
                    //for getting value based on gameobject name
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
        }

        
        private void OnCollisionEnter(Collision collision)
        {
            //for the spacial keys
            if (textValue == "backspace" &&  collision.gameObject.name.Contains("finger"))
            {
                master.removeText(1);
                testClick = false;
            }
            else if (textValue.Contains("shift") && !master.isShifted && collision.gameObject.name.Contains("finger"))
            {
                master.isShifted = true;
                testClick = false;
            } 
            else if (textValue.Contains("shift") && master.isShifted && collision.gameObject.name.Contains("finger"))
            {
                master.isShifted = false;
                testClick = false;
            }
            else if (textValue == "space" && collision.gameObject.name.Contains("finger"))
            {
                master.addText(" ");
                testClick = false;
            }
            else if (textValue == "copy" && collision.gameObject.name.Contains("finger"))
            {
                master.CopiesString = master.currentText.text;
                testClick = false;
            }
            else if (textValue == "paste" && collision.gameObject.name.Contains("finger"))
            {
                master.addText(master.CopiesString);
                testClick = false;
            }
            else if (textValue == "enter" && collision.gameObject.name.Contains("finger"))
            {
                master.preformAction();
                testClick = false;
            }
            else if (collision.gameObject.name.Contains("finger"))
            {
                testClick = false;
                master.addText(textValue);
            }

        }
    }
}
