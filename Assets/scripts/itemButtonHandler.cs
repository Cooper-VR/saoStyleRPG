using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.inventory
{
    public class itemButtonHandler : MonoBehaviour
    {
        int index;

        public bool deleteObjectTest;
        public collisionChecker collisionChecker;
        public inventoryObjects item;

        public enum buttonType{
            delete,
            spawn
        }

        private void Start()
        {
            collisionChecker = GetComponent<collisionChecker>();
        }

        public buttonType type;

        private void Update()
        {
            index = Convert.ToInt32(transform.parent.parent.name[transform.parent.parent.name.Length - 1]);

            if (deleteObjectTest)
            {
                deleteItem();
                deleteObjectTest = false;
            }

            if (type == buttonType.spawn && collisionChecker.entered && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                spawnItem();
            }
            else if (type == buttonType.delete && collisionChecker.entered && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                deleteItem();
            }
        }

        private void deleteItem()
        {
            Debug.Log("poof");
            GameObject.Find("[CameraRig]").GetComponent<inventory>().removeItem(index, item.objectType);
        }
        private void spawnItem()
        {
            //spawn item.prefabObject
        }
    }
}
