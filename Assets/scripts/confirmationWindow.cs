using SAOrpg.playerAPI;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindow : MonoBehaviour
    {
        //fuck it byte cause cant null a boolean
        /// <summary>
        /// opens a yes/no window. will call the method in the atached script
        /// </summary>
        /// <param name="attachedScript">attached script (jus use 'this')</param>
        /// <param name="endMethod">could have this be called at all times untll a boolean is !null</param>
        public static byte openWindow(MonoBehaviour attachedScript, string endMethod)
        {
            //can make it global for some reason
            confirmationWindowControl window = null;

            //spawn the window, just turn it on and off...no spawn
            window = GameObject.Find("windowName").GetComponent<confirmationWindowControl>();

            //check if any of them are a finger
            if (window.yes.collidedGameobject != null)
            {
                return 1;
            }
            else if (window.no.collidedGameobject != null)
            {
                return 0;
            }
            else
            {
                return 2;
            } 

            //return yes/no

            //if no finger is tuoch ing it return null

            //in other script just use a null check

            attachedScript.SendMessage(endMethod);
        }
    }
}
