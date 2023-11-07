using NUnit.Framework;
using SAOrpg.items;
using SAOrpg.playerAPI;
using SAOrpg.playerAPI.RPGsstuff.stats;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace SAOrpg
{
	public class swordSkillCreator : EditorWindow
	{
		private poseDirectionObject writtingObject;
		private recordMode mode;
		private usingHand swingHand;

		private bool recordingPose;
		private bool recordingCombo;

		private GameObject quaderentContainer;
		private GameObject sword;
		private GameObject hittingDummy;

		private collisionChecker leftHand;
		private collisionChecker rightHand;
        private collisionChecker swordEnd_L;
        private collisionChecker swordEnd_R;

        [MenuItem("Window/Tools/SwordSkilCreator")]
		private static void click()
		{
			EditorWindow.GetWindow(typeof(swordSkillCreator), false, "Sword Skill Creator");
		}

		private void OnGUI()
		{
            EditorGUILayout.LabelField("record buttons");
            EditorGUILayout.LabelField("Record pose");

			// Add a button
			if (GUILayout.Button("start recording"))
			{
				Debug.Log("wait 5 sec");
				mode = recordMode.pose;

                recordWait();
            }

			EditorGUILayout.LabelField("Record Combo");

			// Add a button
			if (GUILayout.Button("start recording"))
			{
				Debug.Log("wait 5 sec till record");
				mode = recordMode.directions;

				recordWait();

            }

			// Add a button
			if (GUILayout.Button("Mirror pose/movement"))
			{
				mirrorPose(writtingObject);

				if (swingHand == usingHand.left)
				{
					writtingObject.comboDirection_R.Clear();
                    poseDirectionObject.directions[] directions = mirrorDirection(writtingObject.comboDirection_L.ToArray());

                    for (int i = 0; i < directions.Length; i++)
                    {
                        writtingObject.comboDirection_R.Add(directions[i]);
                    }
				}
				else
				{
                    writtingObject.comboDirection_L.Clear();
                    poseDirectionObject.directions[] directions = mirrorDirection(writtingObject.comboDirection_R.ToArray());

                    for (int i = 0; i < directions.Length; i++)
                    {
                        writtingObject.comboDirection_L.Add(directions[i]);
                    }
                }
				

                Debug.Log("Mirror");
			}

            EditorGUILayout.Space(15);
            EditorGUILayout.LabelField("settings");
            writtingObject = EditorGUILayout.ObjectField("object To write to", writtingObject, typeof(poseDirectionObject), true) as poseDirectionObject;
			swingHand = (usingHand)EditorGUILayout.EnumPopup("swinging hand", swingHand);
            quaderentContainer = EditorGUILayout.ObjectField("quaderent Container", quaderentContainer, typeof(GameObject), true) as GameObject;
            sword = EditorGUILayout.ObjectField("test sword", sword, typeof(GameObject), true) as GameObject;
			hittingDummy = EditorGUILayout.ObjectField("dummy object", hittingDummy, typeof(GameObject), true) as GameObject;

            EditorGUILayout.Space(15);
			EditorGUILayout.LabelField("collision objects");

            leftHand = EditorGUILayout.ObjectField("left hand", leftHand, typeof(collisionChecker), true) as collisionChecker;
            rightHand = EditorGUILayout.ObjectField("right hand", rightHand, typeof(collisionChecker), true) as collisionChecker;
            swordEnd_L = EditorGUILayout.ObjectField("left sword end", swordEnd_L, typeof(collisionChecker), true) as collisionChecker;
            swordEnd_R = EditorGUILayout.ObjectField("right sword end", swordEnd_R, typeof(collisionChecker), true) as collisionChecker;
        }

		private poseDirectionObject.directions[] mirrorDirection(poseDirectionObject.directions[] directionsList)
		{
			poseDirectionObject.directions[] mirroredDirection = new poseDirectionObject.directions[directionsList.Length];

			for (int i = 0; i < directionsList.Length; i++)
			{
				switch (directionsList[i])
				{
					case (poseDirectionObject.directions.left):
						mirroredDirection[i] = poseDirectionObject.directions.right;
						break;
                    case (poseDirectionObject.directions.right):
                        mirroredDirection[i] = poseDirectionObject.directions.right;
                        break;
                    case (poseDirectionObject.directions.leftDown):
                        mirroredDirection[i] = poseDirectionObject.directions.leftDown;
                        break;
                    case (poseDirectionObject.directions.rightDown):
                        mirroredDirection[i] = poseDirectionObject.directions.rightDown;
                        break;
                    case (poseDirectionObject.directions.leftUp):
                        mirroredDirection[i] = poseDirectionObject.directions.leftUp;
                        break;
                    case (poseDirectionObject.directions.rightUp):
                        mirroredDirection[i] = poseDirectionObject.directions.rightUp;
                        break;
					default:
						mirroredDirection[i] = directionsList[i];
						break;
                }
			}

			return mirroredDirection;
			
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

		private void recordPose()
		{
			collisionChecker swordEnd;

			if (swingHand == usingHand.left)
			{
				swordEnd = swordEnd_L;
            }
			else
			{
				swordEnd = swordEnd_R;
			}

			//check if the name is correct
			//get number
			//put in array
            if (leftHand.collidedGameobject.name.Contains("Q:"))
            {

                writtingObject.using_L[0] = Convert.ToInt32(rightHand.collidedGameobject.name[rightHand.collidedGameobject.name.Length - 1]);
            }
            if (rightHand.collidedGameobject.name.Contains("Q:"))
            {

                writtingObject.using_L[1] = Convert.ToInt32(leftHand.collidedGameobject.name[leftHand.collidedGameobject.name.Length - 1]);
            }
            if (swordEnd.collidedGameobject.name.Contains("Q:"))
            {

                writtingObject.using_L[2] = Convert.ToInt32(swordEnd.collidedGameobject.name[swordEnd.collidedGameobject.name.Length - 1]);
            }

			recordingPose = false;
        }

		private void recordCombo(GameObject hitObject)
		{
			itemDamager damger = sword.GetComponent<itemDamager>();
			collisionChecker checker = sword.GetComponent<collisionChecker>();

			if (checker.entered)
			{
				if (checker.collidedGameobject == hitObject)
				{
					writtingObject.comboDirection_L.Add(damger.lastHitDirection);
				}
			}
		}

        private void Update()
        {
            if (recordingPose)
			{
				recordPose();
            }
			if (recordingCombo)
			{
				recordCombo(hittingDummy);
			}
        }

        public enum usingHand
		{
			left,
			right
		}

		public enum recordMode
		{
			pose,
			directions
		}

        IEnumerator recordWait()
        {
            
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            yield return new WaitForSeconds(5);

            Debug.Log("Finished Coroutine at timestamp : " + Time.time);

			if (mode == recordMode.pose)
			{
				//get quaderents
				recordingPose = true;

            }
			else
			{
				recordingCombo = true;
				//get directions
			}
        }
    }
}
