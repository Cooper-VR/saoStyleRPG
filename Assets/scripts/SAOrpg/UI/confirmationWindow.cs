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
        /// <param name="attachedScript">The little master script that should be spawned</param>
        /// <param name="alertText">the message being displayed</param>
        public static windowStates openWindow(confirmationWindowMaster attachedScript, string alertText)
        {
            //cant make it global for some reason
            confirmationWindowControl window = null;

            //spawn the window, just turn it on and off...no spawn
            window = attachedScript.window;
            window.gameObject.SetActive(true);
            window.text= alertText;

            //check if any of them are a finger
            if (window.yes.entered)
            {
                return windowStates.yes;
            }
            else if (window.no.entered)
            {
                return windowStates.no;
            }
            else
            {
                return windowStates.undecided;
            }     
        }

        /// <summary>
        /// destryoes the window
        /// </summary>
        /// <param name="theWindow">MAKE THIS THE MASTER SO IT DESTROYES THE KID</param>
        public static void closeWindow(GameObject theWindow)
        {
            Destroy(theWindow);
        }
    }
}
