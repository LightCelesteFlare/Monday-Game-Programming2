using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVersion2 : MonoBehaviour {

    public GameObject Survivor;
    public GameObject Enemy;
    public int numberOfSurvivors = 1;
    public int numberOfEnemies = 1 ;

    public float spawnRadius;

    private GameObject[] Survivors;
    private GameObject[] Enemies;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;
    // Use this for initialization
    void Start()
    {
        Survivors = new GameObject[numberOfSurvivors];
        Enemies = new GameObject[numberOfEnemies];
        Spawn(Survivor, numberOfSurvivors);
        Spawn2(Enemy, numberOfEnemies);

    }

    void Spawn(GameObject prefab, int count)
    {        
            for (int i = 0; i < count; i++)
            {

                GameObject Survivor = Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), 1, Random.Range(-spawnRadius, spawnRadius)),
                    Quaternion.identity) as GameObject;
            Survivor.transform.parent = transform;
            //Survivor.transform.localPosition = position;
            //Survivor.GetComponent<BoidFlocking>().SetController(gameObject);
            Survivors[i] = Survivor;
            }
    }
    void Spawn2(GameObject prefab, int count)
    { 
            for (int i = 0; i<count; i++)
            {

                Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), 1, Random.Range(-spawnRadius, spawnRadius)),
                    Quaternion.identity);
                Enemies[i] = Enemy;
            }
    }
    void Party()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        foreach (GameObject boid in Survivors)
        {
            theCenter = theCenter + boid.transform.localPosition;
            theVelocity = theVelocity + boid.GetComponent<Rigidbody>().velocity;
        }

        flockCenter = theCenter / (numberOfSurvivors);
        flockVelocity = theVelocity / (numberOfSurvivors);
    }
}
