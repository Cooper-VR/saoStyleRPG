using SAOrpg.playerAPI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SAOrpg.Login
{
    public class textSelector : MonoBehaviour
    {
        public keyBoardMaster master;
        private collisionChecker checker;
        public bool testBool;

        private void Start()
        {
            checker = GetComponent<collisionChecker>();
        }

        private void Update()
        {
            if (checker.entered && checker.collidedObject.Contains("finger"))
            {
                master.currentText = GetComponent<TMP_Text>();
                testBool = false;
            }
        }
    }
}
