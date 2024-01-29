using UnityEngine;

namespace SAOrpg.NPCs.Menu
{
    public class buttonHandler : MonoBehaviour
    {
        collisionChecker checker;
        bool opened;

        private void Start()
        {
            checker = GetComponent<collisionChecker>();
        }

        private void Update()
        {
            if (checker.entered && checker.collidedObject.Contains("finger"))
            {
                //do action
                if (opened)
                {
                    opened = false;
                }
                if (!opened)
                {
                    opened = true;                
                }

                transform.GetChild(0).gameObject.SetActive(opened);
            }
        }
    }
}
