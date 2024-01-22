using UnityEngine;

namespace SAOrpg.NPCs
{
    public class buttonPosition : MonoBehaviour
    {
        public Transform cam;
        public float distanceThreshold;
        public GameObject mainButton;

        private void Update()
        {
            if ((cam.position - transform.position).magnitude <= distanceThreshold)
            {
                mainButton.SetActive(true);
                SetPosition();
            }
            else
            {
                mainButton.SetActive(false);
            }
        }
        private void SetPosition()
        {
            Vector3 direction = (cam.transform.position - transform.position).normalized;
            direction *= distanceThreshold * 0.35f;
            mainButton.transform.position = direction + transform.position;

            //hackfix cause i have no control over transform.lookat
            mainButton.transform.LookAt(cam, transform.forward * -1);
        }
    }
}
