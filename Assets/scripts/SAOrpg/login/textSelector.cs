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
        public bool testBool;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("finger"))
            {
                master.currentText = GetComponent<TMP_Text>();
                testBool = false;
            }
        }
    }
}
