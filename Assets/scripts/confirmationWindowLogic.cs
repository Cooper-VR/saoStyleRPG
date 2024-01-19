using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI
{
	public class confirmationWindowLogic: MonoBehaviour
	{
		public bool spawnWindow;
		public GameObject MasterPrefab;
		public GameObject MasterInstance;
		public string text;

		//for the instaiting class
		public string methodName;
		public GameObject rootButton;

        private void Start()
        {
            spawnWindow = true;
        }

        private void Update()
		{
			//this is the window logic
			if (spawnWindow)
			{
				//spawns in the master so that it can spawn the window, ima be honest idk why i did it this way
				if (MasterInstance == null)
				{
					//I would try to reference 1 window but muliple became an issue
					MasterInstance = Instantiate(MasterPrefab, Vector3.zero,  Quaternion.identity, transform);
				}

				//this is horrible, i coudmt think of anything else
				switch(confirmationWindow.openWindow(MasterInstance.GetComponent<confirmationWindowMaster>(), text))
				{
					case (confirmationWindow.windowStates.no):
						Debug.Log("answered no");
						confirmationWindow.closeWindow(MasterInstance);
						spawnWindow = false;
						//dont do
						break;
					case (confirmationWindow.windowStates.yes):
						Debug.Log("answered yes");
						confirmationWindow.closeWindow(MasterInstance);
						spawnWindow = false;
						rootButton.SendMessage(methodName);
						break;
					case (confirmationWindow.windowStates.undecided):
						Debug.Log("waiting");
						break;
				}   
			}
		}
	}
}
