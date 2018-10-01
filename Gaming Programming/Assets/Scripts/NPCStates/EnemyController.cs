using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float BattleRating;
    float size = 0f;
    // Use this for initialization
    void Start () {
        BattleRating = Random.Range(50, 1000);

        if (BattleRating <= 250)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(BattleRating, BattleRating);
        }
        if (size >= 2.5)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f,0f,0f,0f,0f,0f,Random.Range(0f,5f),5f);
        }
        transform.localScale += new Vector3(size, size, size);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
