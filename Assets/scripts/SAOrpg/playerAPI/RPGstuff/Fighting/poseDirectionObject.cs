using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.Fighting
{
    [CreateAssetMenu(fileName = "pose", menuName = "ScriptableObjects/player/Pose", order = 2)]
    public class poseDirectionObject : ScriptableObject
    {
        //left, right, sword
        public int[] using_L = new int[3];
        public int[] using_R = new int[3];

        public List<directions> comboDirection_L = new List<directions>();
        public List<directions> comboDirection_R = new List<directions>();


        public enum directions
        {
            left,
            right,
            up,
            down,
            pierce,
            leftUp,
            rightUp,
            leftDown,
            rightDown,
        }
    }
}
