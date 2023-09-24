using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public enemySpawnerObj scriptableObjectParems;
    private float Timer;
    private int totalEnemies;
    public LayerMask groundMask;

    private void Update()
    {
        
        Timer += Time.deltaTime;

        if (Timer > scriptableObjectParems.waitTime)
        {
            totalEnemies = transform.childCount;
            if (totalEnemies < scriptableObjectParems.maxEnemies)
            {
                spawnEnemy();
            }

            Timer = 0;
        }
    }

    private void spawnEnemy()
    {
        GameObject enemy = getEnemyPrefab();
        Vector3 spawnPoint = spawnPosition();
        spawnPoint = shootRayCast(spawnPoint);

        GameObject.Instantiate(enemy, spawnPoint, transform.rotation, transform);
    }

    private Vector3 spawnPosition()
    {
        float randomRotation = UnityEngine.Random.Range(0f, 2 * MathF.PI);

        float randomRadius = UnityEngine.Random.Range(0f, scriptableObjectParems.MaxRadius);

        float xValue = MathF.Cos(randomRotation);
        float yValue = MathF.Sin(randomRotation);

        xValue *= randomRadius;
        yValue *= randomRadius;

        Vector3 randomPosition = transform.position;

        randomPosition.x += xValue;
        randomPosition.z += yValue;

        return randomPosition;
    }

    private Vector3 shootRayCast(Vector3 airPosition)
    {
        airPosition.y += 1000;

        RaycastHit hit;


        if (Physics.Raycast(airPosition, Vector3.down, out hit, 2000f, groundMask))
        {
            return hit.point;
        }
        else
        {
            return transform.position;
        }
    }

    private GameObject getEnemyPrefab()
    {
        int length = scriptableObjectParems.enemiesToSpawn.Length;

        length = RandomNumberGenerator.GetInt32(0, length);

        return scriptableObjectParems.enemiesToSpawn[length];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, scriptableObjectParems.MaxRadius);
    }
}
