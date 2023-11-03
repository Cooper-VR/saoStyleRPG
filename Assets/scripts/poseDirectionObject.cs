using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.stats
{
    [CreateAssetMenu(fileName = "pose", menuName = "ScriptableObjects/player/Pose", order = 2)]
    public class poseDirectionObject : ScriptableObject
    {
        public int leftHandQuadrent_L;
        public int rightHandQuadrent_L;
        public int swordQuadrent_L;

        public int leftHandQuadrent_R;
        public int rightHandQuadrent_R;
        public int swordQuadrent_R;

        public List<directions> comboDirection = new List<directions>();


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
