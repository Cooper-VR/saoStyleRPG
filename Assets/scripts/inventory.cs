using SAOrpg.playerAPI.RPGsstuff.stats;
using TMPro;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.inventory
{
    public class inventory : MonoBehaviour
	{
		public inventoryObjects[] weapons;
		public inventoryObjects[] items;

		public GameObject itemSlotBase;

		public GameObject weaponRoot;
		public GameObject itemsRoot;

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

				newObject.name = weapons[i].name;

				newObject.transform.GetChild(1).GetComponent<TMP_Text>().text = weapons[i].name;
			}

			//update menu
			for (int i = 0; i < items.Length; i++)
			{
				GameObject newObject = GameObject.Instantiate(itemSlotBase, itemsRoot.transform.GetChild(0).GetChild(0));

				newObject.name = items[i].name;

				newObject.transform.GetChild(1).GetComponent<TMP_Text>().text = items[i].name;
			}

			gameObject.GetComponent<playerStats>().weapons = weapons;
			gameObject.GetComponent<playerStats>().items = items;
			ArrayLength = items.Length + weapons.Length;
		}
	}
}
