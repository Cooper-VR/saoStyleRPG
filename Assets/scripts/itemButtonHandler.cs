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

        public inventoryObjects item;

        public enum buttonType{
            delete,
            spawn
        }

        public buttonType type;

        private void Update()
        {
            index = Convert.ToInt32(gameObject.name.Split(":")[0]);

            if (type == buttonType.spawn)
            {
                spawnItem();
            }
            else
            {
                deleteItem();
            }
        }

        private void deleteItem()
        {
            GameObject.Find("[CameraRig]").GetComponent<inventory>().removeItem(index, item.objectType);
        }
        private void spawnItem()
        {
            //spawn item.prefabObject
        }
    }
}
