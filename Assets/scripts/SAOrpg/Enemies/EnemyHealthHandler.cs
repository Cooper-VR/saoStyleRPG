using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SAOrpg.Enemies
{
    public class EnemyHealthHandler : MonoBehaviour
    {
        private SkeletonEnemy enemy;
        public Gradient barColor;
        public MeshRenderer renderer;
        public float percent;

        private void Start()
        {
            enemy = GetComponent<SkeletonEnemy>();
        }


        public void updateHealth()
        {
            percent = (float)enemy.health / (float)enemy.maxHealth;

            renderer.material.SetFloat("_DissolveAlpha", percent);
            renderer.material.SetColor("_DissolveTextureColor", barColor.Evaluate(percent));

        }
    }
}
