using SAOrpg.playerAPI;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindow : MonoBehaviour
    {

        public enum windowStates
        {
            yes,
            no,
            undecided
        }

        //fuck it byte cause cant null a boolean
        /// <summary>
        /// opens a yes/no window. will call the method in the atached script
        /// </summary>
        /// <param name="attachedScript">attached script (jus use 'this')</param>
        /// <param name="endMethod">could have this be called at all times untll a boolean is !null</param>
        public static windowStates openWindow(MonoBehaviour attachedScript, string alertText)
        {
            //cant make it global for some reason
            confirmationWindowControl window = null;

            //spawn the window, just turn it on and off...no spawn
            window = GameObject.Find("windowManger").GetComponent<confirmationWindowMaster>().window;
            window.gameObject.SetActive(true);
            window.text= alertText;

            //check if any of them are a finger
            if (window.yes.TestEnter)
            {
                return windowStates.yes;
            }
            else if (window.no.TestEnter)
            {
                return windowStates.no;
            }
            else
            {
                return windowStates.undecided;
            }     
        }

        public static void closeWindow()
        {
            //cant make it global for some reason
            confirmationWindowControl window = null;

            //spawn the window, just turn it on and off...no spawn
            window = GameObject.Find("windowManger").GetComponent<confirmationWindowMaster>().window;
            window.gameObject.SetActive(false);

        }
    }
}
