using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour {
    public GameObject scale;
    public float point1, point2;
    public bool Direct; // Right
    public float speed = 1f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        scale.gameObject.GetComponent<Renderer>().material.color = Color.black;
        if (Direct)
        {
            scale.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            scale.transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }

        if (scale.transform.position.x >= point1)
        {
            Direct = false;
        }
        if (scale.transform.position.x <= point2)
        {
            Direct = true;
        }
    }
}
