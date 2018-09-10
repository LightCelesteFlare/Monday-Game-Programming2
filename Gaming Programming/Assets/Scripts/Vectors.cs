using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectors : MonoBehaviour {

    public GameObject Ball;
    public float x, y, z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = Random.Range(2, 10);
        y = Random.Range(2, 10);
        z = Random.Range(2, 10);
        Ball.transform.Rotate(x, y, z);
	}
}
