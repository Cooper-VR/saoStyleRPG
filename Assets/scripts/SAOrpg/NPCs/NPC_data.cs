using SAOrpg.NPCs.Menu;
using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.NPCs
{
    public class NPC_data : MonoBehaviour
    {
        public inventoryObjects[] sellingItems;
        public Transform panelRoot;
        public GameObject itemWindowSlotPrefab;

        private void Start()
        {
            for (int i = 0; i < sellingItems.Length; i++)
            {
                itemButton currentPanel = Instantiate(itemWindowSlotPrefab, panelRoot).GetComponent<itemButton>();

                currentPanel.itemPrefab = sellingItems[i];
            }
        }
    }
}
