using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsController : MonoBehaviour {
    public GameObject[] boids;
    public int NumberOfBoids = 100;
    public GameObject boidPrefab;
    public Vector3 targetPos;
    public GameObject targetGO;

    float worldRadius = 25f;
    public Vector3 boidAveragepoint = Vector3.zero;

    public float SeperationCutOffDistance = 10f;

	// Use this for initialization
	void Start () {
        boids = new GameObject[100];
        
		for(int i = 0; i < NumberOfBoids; i++)
        {
            Vector2 newPos2d = UnityEngine.Random.insideUnitCircle;
            float x = newPos2d.x * worldRadius, z = newPos2d.y * worldRadius;
            Quaternion q = UnityEngine.Random.rotationUniform; 
            boids[i]=Instantiate(boidPrefab, new Vector3(x,1,z),Quaternion.identity);
        }
	}

    private void move_all_boids()
    {
        Vector3 v1, v2, v3;
        float w1 = 0.3f, w2 = 0.3f, w3 = 0.3f;
        GameObject boid;
        Vector3 newAverage = Vector3.zero;
        for (int i = 0; i < NumberOfBoids; i++)
        {
            boid = boids[i];
            v1 = Rule_Seperation(boid); // Seperation
                                        //v2 = Rule_Alignment(boid); // Alignment
            v2 = boidAveragepoint * Time.deltaTime;
            v3 = Rule_Cohesion(boid); // Cohesion
            Vector3 v = v1 * w1 + v2 * w2 + v3 * w3;
            newAverage += v;
            Vector3 newPos = boid.transform.position + v * Time.deltaTime;
            boid.transform.position = newPos;
        }
        boidAveragepoint = newAverage / NumberOfBoids;
    }

    private Vector3 Rule_Cohesion(GameObject boid)
    {
        Vector3 centerofGravity = Vector3.zero;
        for (int i = 0; i < NumberOfBoids; i++)
        {
            if (boid != boids[i])
            {
                centerofGravity += boids[i].transform.position;
            }
        }
        return centerofGravity / (NumberOfBoids - 1);
    }

    //private Vector3 Rule_Alignment(GameObject boid)
    //{
    //    Vector3 centerofGravity = Vector3.zero;
    //    for (int i = 0; i < NumberOfBoids; i++)
    //    {
    //        if (boid != boids[i])
    //        {
    //            centerofGravity += boids[i].transform.position;
    //        }
    //    }
    //    return centerofGravity / (NumberOfBoids - 1);
    //}

    private Vector3 Rule_Seperation(GameObject boid)
    {
        Vector3 vSeperator = Vector3.zero;
        for (int i = 0; i < NumberOfBoids; i++)
        {
            if (boid != boids[i])
            {
                Vector3 dir = boid.transform.position;
                if (dir.magnitude < SeperationCutOffDistance)
                {
                    vSeperator += dir;
                }

            }
        }
        return vSeperator / (NumberOfBoids - 1);

    }

    // Update is called once per frame
    void Update () {
        move_all_boids();

    }
}
