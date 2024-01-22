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

        float timeElapsed;
        float lerpDuration = 3;
        float startValue = -1;
        float endValue = 1;
        float valueToLerp;
		Material[] mats;
		GameObject spawnedItem;
		bool spawned = false;

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
			

			if (deleteObjectTest)
			{
				spawnItem();
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

            if (timeElapsed < lerpDuration && spawned)
            {
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
				spawnedItem.GetComponent<Rigidbody>().isKinematic = true;
				for (int i = 0; i < mats.Length; i++)
				{
					mats[i].SetFloat("_GeoDissolveAlpha", valueToLerp * -1);
				}

                timeElapsed += Time.deltaTime;
            }else if (spawned)
			{
                spawnedItem.GetComponent<Rigidbody>().isKinematic = false;
                deleteItem();
				spawned = false;
			}
        }

		private void deleteItem()
		{
			Debug.Log(transform.parent.parent.name.Split(": ")[1]);
            index = Convert.ToInt32(transform.parent.parent.name.Split(": ")[1]);
            GameObject.Find("[CameraRig]").GetComponent<inventory>().removeItem(index, item.objectType);
		}
		private void spawnItem()
		{
			spawnedItem = Instantiate(item.objectPrefab, transform.position, transform.rotation);

			mats = spawnedItem.transform.GetChild(0).GetComponent<MeshRenderer>().materials;

			spawned = true;


			//spawn item.prefabObject
		}
	}
}
