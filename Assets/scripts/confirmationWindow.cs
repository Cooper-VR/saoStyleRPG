using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindow : MonoBehaviour
    {
        public GameObject window;

        /// <summary>
        /// opens a yes/no window. will call the method in the atached script
        /// </summary>
        /// <param name="attachedScript">attached script (jus use 'this')</param>
        /// <param name="endMethod">could have this be called at all times untll a boolean is !null</param>
        public static void openWindow(MonoBehaviour attachedScript, string endMethod)
        {
            //spawn the window

            //get both buttons collision data

            //check if any of them are a finger

            //return yes/no

            //if no finger is tuoch ing it return null

            //in other script just use a null check

            attachedScript.SendMessage(endMethod);
        }
    }
}
