using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectors : MonoBehaviour
{

    public GameObject Ball;
    public float x, y, z, p;

    // Use this for initialization
    void Start()
    {
        p = Random.Range(0, 1);
        Ball.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.2f, 1f);
        Physics.gravity = new Vector3(p, p);
    }

    // Update is called once per frame
    void Update()
    {

        x = Random.Range(2, 10);
        y = Random.Range(2, 10);
        z = Random.Range(2, 10);
        Ball.transform.Rotate(x, y, z);

    }
}