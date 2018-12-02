using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapController : MonoBehaviour {
    public float SXmin = 1.5f, SXmax = 2.5f;
    float dx;

    public float flapperduration = 6;
	// Use this for initialization
	void Start () {
        dx = SXmax - SXmin;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector3(SXmin + dx / 2 + dx * Mathf.Sin(Time.fixedTime * flapperduration),1.1f,0.3f);
	}
}
