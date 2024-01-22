using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.audio
{
    [CreateAssetMenu(fileName = "audioArrays", menuName = "ScriptableObjects/player/audio", order = 1)]
    public class soundArray : ScriptableObject
    {
        public AudioClip[] audio;
    }
}
