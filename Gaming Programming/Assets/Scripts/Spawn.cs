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
            Debug.Log("Left mouse clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "floor")
                {
                    Instantiate(Prefeb, hit.point, Quaternion.identity);
                    print("My object is clicked by mouse");
                }
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 instantiatePosition = Input.mousePosition;
        //    Point = instantiatePosition;
        //    GameObject newGameObject = Instantiate(Prefeb, Point, Quaternion.identity);
        //}
    }
}

