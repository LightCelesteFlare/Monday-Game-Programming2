using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject Prefeb;
    private Vector3 Point;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 instantiatePosition = Input.mousePosition;
            Point = instantiatePosition;
            GameObject newGameObject = Instantiate(Prefeb, Point, Quaternion.identity);
        }
    }
}

