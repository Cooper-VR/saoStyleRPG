using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEditor;
using UnityEngine;

namespace SAOrpg
{
	public class swordSkillCreator : EditorWindow
	{
		private poseDirectionObject writtingObject;

		private usingHand swingHand;

		[MenuItem("Window/Tools/SwordSkilCreator")]
		private static void click()
		{
			EditorWindow.GetWindow(typeof(swordSkillCreator), false, "Sword Skill Creator");
		}

		private void OnGUI()
		{
			EditorGUILayout.LabelField("Record pose");

			// Add a button
			if (GUILayout.Button("start recording"))
			{
				Debug.Log("wait 5 sec");
			}

			EditorGUILayout.LabelField("Record Combo");

			// Add a button
			if (GUILayout.Button("start recording"))
			{
				Debug.Log("wait 5 sec till record");
			}

			// Add a button
			if (GUILayout.Button("Mirror pose/movement"))
			{
				mirrorPose(writtingObject);


                Debug.Log("Mirror");
			}

			writtingObject = EditorGUILayout.ObjectField("object To write to", writtingObject, typeof(poseDirectionObject), true) as poseDirectionObject;
			swingHand = (usingHand)EditorGUILayout.EnumPopup("swinging hand", swingHand);
		}

		private poseDirectionObject.directions[] mirrorDirection(poseDirectionObject.directions[] directionsList)
		{
			poseDirectionObject.directions[] mirroredDirection = new poseDirectionObject.directions[directionsList.Length];

			if (swingHand == usingHand.left)
			{
				
			}

			if (swingHand == usingHand.right)
			{

			}

			return directionsList;
		}

		private void mirrorPose(poseDirectionObject poseObject)
		{
			if (swingHand == usingHand.left)
			{
                poseObject.using_R = new int[poseObject.using_L.Length];

                for (int i = 0; i < poseObject.using_L.Length; i++)
				{
					if (poseObject.using_L[i] % 2 == 0)
					{
						poseObject.using_R[i] = poseObject.using_L[i] - 1;
					}
					else
					{
						poseObject.using_R[i] = poseObject.using_L[i] + 1;
					}
				}
			}

			if (swingHand == usingHand.right)
			{
				poseObject.using_L = new int[poseObject.using_R.Length];

                for (int i = 0; i < poseObject.using_R.Length; i++)
                {
                    if (poseObject.using_R[i] % 2 == 0)
                    {
                        poseObject.using_L[i] = poseObject.using_R[i] - 1;
                    }
                    else
                    {
                        poseObject.using_L[i] = poseObject.using_R[i] + 1;
                    }
                }
            }
		}

		public enum usingHand
		{
			left,
			right
		}
	}
}
