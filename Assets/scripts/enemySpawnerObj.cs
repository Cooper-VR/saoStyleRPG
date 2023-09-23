using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawner", menuName = "enemies/spawnerParems")]
public class enemySpawnerObj : ScriptableObject
{
    public GameObject[] enemiesToSpawn;
    public int maxEnemies;
    public int waitTime;
    public float MaxRadius;
}
