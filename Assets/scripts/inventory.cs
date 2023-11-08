using SAOrpg.playerAPI.RPGsstuff.stats;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

namespace SAOrpg.playerAPI.RPGsstuff.inventory
{
    public class inventory : MonoBehaviour
	{
		public inventoryObjects[] weapons;
		public inventoryObjects[] items;

		public GameObject itemSlotBase;

		public GameObject weaponRoot;
		public GameObject itemsRoot;

		public inventoryObjects upperArmor;
		public inventoryObjects lowerArmor;

		private int ArrayLength;

		private void Update()
		{
			if (ArrayLength != weapons.Length + items.Length)
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
			for (int i = 0; i < weapons.Length; i++)
			{
				GameObject newObject = GameObject.Instantiate(itemSlotBase, weaponRoot.transform.GetChild(0).GetChild(0));

				newObject.name = weapons[i].name + ": " + i.ToString();

				newObject.transform.GetChild(1).GetComponent<TMP_Text>().text = weapons[i].name;

                newObject.transform.GetChild(2).GetChild(0).GetComponent<itemButtonHandler>().item = weapons[i];
                newObject.transform.GetChild(2).GetChild(1).GetComponent<itemButtonHandler>().item = weapons[i];
            }

			//update menu
			for (int i = 0; i < items.Length; i++)
			{
				GameObject newObject = GameObject.Instantiate(itemSlotBase, itemsRoot.transform.GetChild(0).GetChild(0));

				newObject.name = items[i].name + ": " + i.ToString();

				newObject.transform.GetChild(1).GetComponent<TMP_Text>().text = items[i].name;

                newObject.transform.GetChild(2).GetChild(0).GetComponent<itemButtonHandler>().item = items[i];
                newObject.transform.GetChild(2).GetChild(1).GetComponent<itemButtonHandler>().item = items[i];
            }

			gameObject.GetComponent<playerStats>().weapons = weapons;
			gameObject.GetComponent<playerStats>().items = items;
			ArrayLength = items.Length + weapons.Length;
		}

		public void removeItem(int index, inventoryObjects.ObjectType itemType)
		{
			inventoryObjects[] newArray;

			if (itemType == inventoryObjects.ObjectType.weapon)
			{
				newArray = new inventoryObjects[weapons.Length - 1];
				for (int i = 0;i < newArray.Length;i++)
				{
					if (i != index)
					{
						newArray[i] = weapons[i];
					}
					else
					{
						i++;
					}
				}

				List<inventoryObjects> tempList = new List<inventoryObjects>();
                for (int i = 0; i < weapons.Length; i++)
				{
					tempList.Add(weapons[i]);
				}

                tempList.RemoveAt(index);
                weapons = tempList.ToArray();
			}

            if (itemType == inventoryObjects.ObjectType.item)
            {
                newArray = new inventoryObjects[items.Length - 1];
                for (int i = 0; i < newArray.Length; i++)
                {
                    if (i != index)
                    {
                        newArray[i] = items[i];
                    }
                    else
                    {
                        i++;
                    }
                }

                items = newArray;
            }
        }
	}
}
