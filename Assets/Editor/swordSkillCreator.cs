using SAOrpg.playerAPI.RPGsstuff.stats;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SAOrpg
{
    public class swordSkillCreator : EditorWindow
    {
        private poseDirectionObject writtingObject;


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
            }

            EditorGUILayout.LabelField("Record Combo");

            // Add a button
            if (GUILayout.Button("start recording"))
            {
            }

            // Add a button
            if (GUILayout.Button("Mirror pose/movement"))
            {
            }

            writtingObject = EditorGUILayout.ObjectField("root object", writtingObject, typeof(poseDirectionObject), true) as poseDirectionObject;
        }
    }
}
