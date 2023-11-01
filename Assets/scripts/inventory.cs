using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SAOrpg.playerAPI.RPGsstuff.inventory
{
    public class inventory : MonoBehaviour
    {
        public inventoryObjects[] weapons;
        public inventoryObjects[] items;

        public GameObject itemSlotBase;

        public GameObject weaponRoot;
        public GameObject itemsRoot;

        private void Start()
        {
            addObject();
        }

        public void addObject()
        {
            //update menu
            for (int i = 0; i < weapons.Length; i++)
            {
                GameObject newObject = GameObject.Instantiate(itemSlotBase, weaponRoot.transform.GetChild(0).GetChild(0));

                newObject.name = weapons[i].name;

                
            }

            for (int i = 0;i < items.Length; i++)
            {

            }
        }
    }
}
