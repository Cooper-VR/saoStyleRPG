using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SAOrpg.playerAPI.RPGstuff.Fighting
{
    public class PickupableObject : MonoBehaviour
    {
        #region variables
        public Transform alignmentObject;
        public Vector3 rotationOffset;
        public rigidBodyGravity rigidBodyBehavior;

        private bool dropped;

        [Header("test stuff")]
        public Transform controller;
        #endregion

        #region helper function

        /// <summary>
        /// is the object should use gravity or not
        /// </summary>
        public enum rigidBodyGravity
        {
            useGravity,
            noGravity
        }

        /// <summary>
        /// will align the object to the alignment object
        /// </summary>
        public void positionItem()
        {
            transform.position = controller.position;
            transform.rotation = Quaternion.Euler(alignmentObject.rotation.eulerAngles + rotationOffset);

            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        /// <summary>
        /// when the item is dropped
        /// </summary>
        public void itemDropped()
        {
            Vector3 droppedVelocity = gameObject.GetComponent<VelocityEstimator>().GetVelocityEstimate();
            gameObject.GetComponent<Rigidbody>().velocity = droppedVelocity;

            if (rigidBodyBehavior == rigidBodyGravity.useGravity)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        #endregion
    }

}



