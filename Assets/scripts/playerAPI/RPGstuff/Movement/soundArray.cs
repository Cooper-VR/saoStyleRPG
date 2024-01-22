using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.Movement
{
    [CreateAssetMenu(fileName = "audioArrays", menuName = "ScriptableObjects/player/audio", order = 1)]
    public class soundArray : ScriptableObject
    {
        public AudioClip[] audio;
    }
}
