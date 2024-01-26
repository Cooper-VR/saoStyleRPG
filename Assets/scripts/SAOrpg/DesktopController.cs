using UnityEngine;
using UnityEngine.SpatialTracking;
using Valve.VR;

namespace SAOrpg
{
    public class DesktopController : MonoBehaviour
    {
        public bool inVR; 
        
        [Tooltip("This action lets you know when the player has placed the headset on their head")]
        public SteamVR_Action_Boolean headsetOnHead = SteamVR_Input.GetBooleanAction("HeadsetOnHead");

        public SteamVR_CameraHelper cameraHelper;
        public GameObject Controller_L;
        public GameObject Controller_R;

        public Transform tinyColider;
        private bool moving;



        void Update()
        {
            if (Input.GetAxis("Fire3") == 1)
            {
                desktopTouch();
            }

            if (moving)
            {
                tinyColider.localPosition += (new Vector3(0, 0, 1f) * Time.deltaTime); // Move the object in the direction of the target's forward direction
            }

            if ((tinyColider.transform.position - cameraHelper.transform.position).magnitude > 5f)
            {
                moving = false;
                tinyColider.transform.position = cameraHelper.transform.position;
            }

            updateDevices();

            if (headsetOnHead != null)
            {

                if (headsetOnHead.GetStateDown(SteamVR_Input_Sources.Head))
                {
                    inVR = true;   
                }

                else if (headsetOnHead.GetStateUp(SteamVR_Input_Sources.Head))
                {
                    inVR = false;
                }
            }
            else
            {
                inVR = false;
            }
        }

        void updateDevices()
        {
            cameraHelper.enabled = inVR;
            cameraHelper.gameObject.GetComponent<TrackedPoseDriver>().enabled = inVR;

            cameraHelper.transform.localPosition = new Vector3(0, 1.72f, 0);

            Controller_L.SetActive(inVR);
            Controller_R.SetActive(inVR);
            tinyColider.gameObject.SetActive(!inVR);
        }

        void desktopTouch()
        {

            //move collider cause unity cant handle collisions good at all
            //this means that the collsion script we have fucks up and break if you turn off an object WHILE its colliding
            tinyColider.position = cameraHelper.transform.position;

            moving = true;
        }
    }
}
