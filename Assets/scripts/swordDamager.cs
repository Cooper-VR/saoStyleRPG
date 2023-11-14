using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class swordDamager : MonoBehaviour
{
    private VelocityEstimator velocityEstimator;
    public float speed;

    private void Start()
    {
        velocityEstimator = GetComponent<VelocityEstimator>();
    }

    private void Update()
    {
        speed = velocityEstimator.GetVelocityEstimate().magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && velocityEstimator.GetVelocityEstimate().magnitude > 3f)
        {
            Debug.Log("hit enemy");
            DamageEnemy(other.transform.parent.parent.parent.gameObject);
        }
    }

    private void DamageEnemy(GameObject enemy)
    {
        enemyAI AI = enemy.GetComponent<enemyAI>();

        AI.bokoAnimator.SetBool("interupt", true);
    }
}
