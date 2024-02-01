using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.Enemies
{
    public class EnemyHealthHandler : MonoBehaviour
    {
        private EnemyBehavior enemy;
        public Gradient barColor;
        public MeshRenderer renderer;
        public float percent;

        private void Start()
        {
            enemy = GetComponent<EnemyBehavior>();
        }

        private void Update()
        {
            percent = (float)enemy.health / (float)enemy.maxHealth;

            renderer.material.SetFloat("_DissolveAlpha", percent);
            renderer.material.SetColor("_DissolveTextureColor", barColor.Evaluate(percent));
        }
    }
}
