using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class colliderAdder : EditorWindow
{
	private GameObject rootObject;


	[MenuItem("Window/Tools/colliderAdder")]
	private static void click()
	{
		EditorWindow.GetWindow(typeof(colliderAdder), false, "collider adder");
	}

	private void OnGUI()
	{
		EditorGUILayout.LabelField("add colliders to objects");

		// Add a button
		if (GUILayout.Button("add colliders"))
		{
			//stuff here

			//get children
			GameObject[] rootChildren = new GameObject[rootObject.transform.childCount];
			for (int i = 0; i < rootChildren.Length; i++) { rootChildren[i] = rootObject.transform.GetChild(i).gameObject; }

			//get acual objects
			GameObject[] baseObjects = new GameObject[rootChildren[0].transform.childCount];
			for (int i = 0; i < baseObjects.Length; i++) { baseObjects[i] = rootChildren[0].transform.GetChild(i).gameObject; }

			GameObject[] baseObjects2 = new GameObject[rootChildren[1].transform.childCount];
			for (int i = 0; i < baseObjects2.Length; i++) { baseObjects2[i] = rootChildren[1].transform.GetChild(i).gameObject; }

			//add colliders
			for (int i = 0;i < baseObjects.Length; i++)
			{
                addColliders(baseObjects[i]);
            }
            for (int i = 0; i < baseObjects2.Length; i++)
            {
                addColliders(baseObjects2[i]);
            }

            
		}

		rootObject = EditorGUILayout.ObjectField("root object", rootObject, typeof(GameObject), true) as GameObject;
	}

	private void addColliders(GameObject currentObject)
	{
		for (int i = 0;i < currentObject.transform.childCount; i++)
		{
			SkinnedMeshRenderer renderer;
			MeshCollider col;

			if (currentObject.transform.GetChild(i).TryGetComponent<SkinnedMeshRenderer>(out renderer))
			{
				if (!currentObject.transform.GetChild(i).TryGetComponent<MeshCollider>(out col))
				{
					if (!currentObject.name.ToLower().Contains("flower") && !currentObject.name.ToLower().Contains("bush") && !currentObject.name.ToLower().Contains("leaf") && !currentObject.name.ToLower().Contains("plant"))
					{
                        currentObject.transform.GetChild(i).gameObject.AddComponent<MeshCollider>();
                        currentObject.transform.GetChild(i).gameObject.GetComponent<MeshCollider>().sharedMesh = renderer.sharedMesh;
                    }
                }
			}
			else
			{
				Debug.Log("not found");
			}
		}
	}
}
