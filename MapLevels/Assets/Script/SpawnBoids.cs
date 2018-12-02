using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoids : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public int counter = 1;
    public float timer;
    public float waitTime;
    // Use this for initialization
    void Start () {
        waitTime = Random.Range(1f, 10f);
    }

    // Update is called once per frame
    void Update() {


        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            waitTime = Random.Range(1f, 10f);
            spawner();
            timer = 0f;
        }
    }
    void spawner() {
        for (int i = 0; i < counter; i++)
        {
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 7;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 8.0f);
        }
    }
}

