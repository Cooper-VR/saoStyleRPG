using SAOrpg.playerAPI;
using SAOrpg.playerAPI.RPGsstuff.inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SAOrpg.items
{
    public class PickupableObject : MonoBehaviour
    {
        #region variables
        public Transform alignmentObject;
        public Vector3 rotationOffset;
        public rigidBodyGravity rigidBodyBehavior;
        public inventoryObjects scriptbleObejct;
        private collisionChecker collisionChecker;

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
            collisionChecker = GetComponent<collisionChecker>();
            if (collisionChecker.currentlyTouching && collisionChecker.collidedObject.Contains("sheath"))
            {
                transform.SetParent(collisionChecker.collidedGameobject.transform);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }else if (collisionChecker.currentlyTouching && collisionChecker.collidedObject.Contains("Canvas"))
            {
                if (scriptbleObejct.objectType == inventoryObjects.ObjectType.weapon)
                {
                    inventoryObjects[] tempArray = gameObject.GetComponent<itemDamager>().playerCamera.parent.GetComponent<inventory>().weapons;

                    inventoryObjects[] newArray = new inventoryObjects[tempArray.Length + 1];

                    for (int i = 0; i < newArray.Length; i++)
                    {
                        
                        if (i < tempArray.Length - 1)
                        {
                            newArray[i] = scriptbleObejct;
                        }
                        else
                        {
                            newArray[i] = tempArray[i];
                        }
                    }
                }
                
            }
            else
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

            
        }

        #endregion
    }

}



