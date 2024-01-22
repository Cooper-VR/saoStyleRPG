using UnityEngine;

namespace SAOrpg
{
    public class findVariable : MonoBehaviour
    {
        public bool hasFound = false;
        public bool interupt = true;
        public void switchVariable()
        {
            interupt = false;
            hasFound = true;
        }
    }
}
