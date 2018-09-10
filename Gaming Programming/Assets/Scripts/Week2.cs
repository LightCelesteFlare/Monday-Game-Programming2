using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2 : MonoBehaviour {
    Vector3 v1;
    Vector3 v2;
    Vector3 v3;
    float alpha = 5;
    float beta = 3;
    // Use this for initialization
    void Start () {
        ClassWork();
    }
	
    void ClassWork()
    {
        v1 = new Vector3(1, 2, 3);
        v2 = new Vector3(5, 4, 3);

        Debug.Log("v1=" + v1);
        Debug.Log("v2=" + v2);

        Debug.Log("v1 + v2 =" + (v1 + v2));
        Debug.Log("v1 - v2 =" + (v1 - v2));

        Debug.Log("alpha * v1 =" + (alpha * v1));
        Debug.Log("alpha * v2 =" + (beta * v2));

        float v1_magnitude = v1.magnitude;
        float v2_magnitude = v2.magnitude;
        Debug.Log("|v1| =" + v1_magnitude);
        Debug.Log("|v2| =" + v2_magnitude);

        Vector3 v1u = v1.normalized; //v1 unit vector (v1 direction)
        Vector3 v1u_my = v1 / v1_magnitude;

        Debug.Log("v1u=" + v1u);
        Debug.Log("v1u_my =" + v1u_my);

        Vector3 v2u = v2.normalized; //v2 unit vector (v1 direction)
        Vector3 v2u_my = v2 / v2_magnitude;

        Debug.Log("v2u=" + v1u);
        Debug.Log("v2u_my =" + v1u_my);

        Debug.Log("v1.v2 =" + Vector3.Dot(v1, v2));
        Debug.Log("v2.v1=" + Vector3.Dot(v2, v1));

        Debug.Log("v1u.v2u=" + Vector3.Dot(v1u, v2u));
        Debug.Log("cos(angle(v1u,v2u))=" + Vector3.Dot(v1u, v2u));

        Debug.Log("v1xv2 = " + Vector3.Cross(v1, v2));
        Debug.Log("v2xv1 = " + Vector3.Cross(v2, v1));

    }
    // Update is called once per frame
    void Update () {
		
	}
}
