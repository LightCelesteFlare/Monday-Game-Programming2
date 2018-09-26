// To load the scene in Unity3D
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code by Renaissance Coders
public class Level : MonoBehaviour {

    public Transform SurvivorPrefab;
    public Transform EnemyPrefab;
    public int numberOfSurvivors;
    public int numberOfEnemies;
    public List<SurvivorController> survivors;
    public List<EnemyController> enemies;
    public float bounds;
    public float spawnRadius;

    // Use this for initialization
    void Start() {
        survivors = new List<SurvivorController>();
        enemies = new List<EnemyController>();

        Spawn(SurvivorPrefab, numberOfSurvivors);
        Spawn(EnemyPrefab, numberOfEnemies);

        survivors.AddRange(FindObjectsOfType<SurvivorController>());
        enemies.AddRange(FindObjectsOfType<EnemyController>());
    }

    void Spawn(Transform prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), 1, Random.Range(-spawnRadius, spawnRadius)),
                Quaternion.identity);
        }
    }

    // moved to the SurvivorController script
    public List<SurvivorController> GetNeighbors(SurvivorController survivor, float radius)
    {
        List<SurvivorController> neighborsFound = new List<SurvivorController>();

        foreach (var otherSurvivor in survivors)
        {
            if (otherSurvivor == survivor)
                continue;

            if (Vector3.Distance(survivor.transform.position, otherSurvivor.transform.position) <= radius)
            {
                neighborsFound.Add(otherSurvivor);
            }
        }
        return neighborsFound;
    }
}
