using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour {
    public GameObject scale;
    public GameObject[] Points;
    public float point1, point2;
    public bool Direct; // Right
    public float speed = 1f;

    public int currentWaypoint = 0;
    public int nextWaypoint;
    int CalculateNextWaypoint()
    {
        return (currentWaypoint + 1) % Points.Length;
    }
    // Use this for initialization
    void Start () {
        Points = GameObject.FindGameObjectsWithTag("Point");
        nextWaypoint = CalculateNextWaypoint();
        transform.position = Points[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update() {
        nextWaypoint = CalculateNextWaypoint();
        //Vector3 p0 = Waypoints[currentWaypoint].transform.position;
        Vector3 p0 = transform.position;
        Vector3 p1 = Points[nextWaypoint].transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p1 - p0).normalized;
        transform.position = newPos;
        if ((newPos - p1).magnitude < .5)
        {
            currentWaypoint = nextWaypoint;
        }
        scale.transform.Rotate(0, 5f, 0);
        //if (Direct)
        //{
        //    scale.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //}
        //else
        //{
        //    scale.transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        //}

        //if (scale.transform.position.x >= point1)
        //{
        //    Direct = false;
        //}
        //if (scale.transform.position.x <= point2)
        //{
        //    Direct = true;
        //}
    }
}
