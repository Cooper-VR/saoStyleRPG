using SAOrpg.playerAPI.RPGstuff.Menu;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.StatsInventory
{
    public class inventory : MonoBehaviour
	{
		public List<inventoryObjects> weapons;
		public List<inventoryObjects> items;

		public GameObject itemSlotBase;

		public GameObject weaponRoot;
		public GameObject itemsRoot;

		public inventoryObjects upperArmor;
		public inventoryObjects lowerArmor;

		private int ArrayLength;

		private void Update()
		{
			if (ArrayLength != weapons.Count + items.Count)
			{
				addObject();
			}
		}

		public void addObject()
		{
			//clear inventory
			// Destroy all child objects
			foreach (Transform child in weaponRoot.transform.GetChild(0).GetChild(0).transform)
			{
				Destroy(child.gameObject);
			}
			// Destroy all child objects
			foreach (Transform child in itemsRoot.transform.GetChild(0).GetChild(0).transform)
			{
				Destroy(child.gameObject);
			}

			//update menu
			for (int i = 0; i < weapons.Count; i++)
			{
				GameObject newObject = GameObject.Instantiate(itemSlotBase, weaponRoot.transform.GetChild(0).GetChild(0));

				newObject.name = weapons[i].name + ": " + i.ToString();

				newObject.transform.GetChild(1).GetComponent<TMP_Text>().text = weapons[i].name;

                newObject.transform.GetChild(2).GetChild(0).GetComponent<itemButtonHandler>().item = weapons[i];
                newObject.transform.GetChild(2).GetChild(1).GetComponent<itemButtonHandler>().item = weapons[i];
            }

			//update menu
			for (int i = 0; i < items.Count; i++)
			{
				GameObject newObject = GameObject.Instantiate(itemSlotBase, itemsRoot.transform.GetChild(0).GetChild(0));

				newObject.name = items[i].name + ": " + i.ToString();

				newObject.transform.GetChild(1).GetComponent<TMP_Text>().text = items[i].name;

                newObject.transform.GetChild(2).GetChild(0).GetComponent<itemButtonHandler>().item = items[i];
                newObject.transform.GetChild(2).GetChild(1).GetComponent<itemButtonHandler>().item = items[i];
            }

			gameObject.GetComponent<playerStats>().weapons = weapons.ToArray();
			gameObject.GetComponent<playerStats>().items = items.ToArray();
			ArrayLength = items.Count + weapons.Count;
		}

		public void removeItem(int index, inventoryObjects.ObjectType itemType)
		{
			inventoryObjects[] newArray;

			if (itemType == inventoryObjects.ObjectType.weapon)
			{
				

				List<inventoryObjects> tempList = new List<inventoryObjects>();
                for (int i = 0; i < weapons.Count; i++)
				{
					tempList.Add(weapons[i]);
				}

                tempList.RemoveAt(index);
				weapons = tempList;
			}

            if (itemType == inventoryObjects.ObjectType.item)
            {
                List<inventoryObjects> tempList = new List<inventoryObjects>();
                for (int i = 0; i < items.Count; i++)
                {
                    tempList.Add(items[i]);
                }

                tempList.RemoveAt(index);
                items = tempList;
            }
        }
	}
}
