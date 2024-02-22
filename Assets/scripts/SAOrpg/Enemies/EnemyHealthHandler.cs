using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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


        public void updateHealth()
        {
            percent = (float)enemy.health / (float)enemy.maxHealth;

            renderer.material.SetFloat("_DissolveAlpha", percent);
            renderer.material.SetColor("_DissolveTextureColor", barColor.Evaluate(percent));

        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "weapon") 
            {
                enemy.health -= 10;
                updateHealth();
            }
        }

        public UnityEvent healthChange;
    }
}
