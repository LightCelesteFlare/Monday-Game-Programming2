using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour {
    public float BattleRating;
    // Use this for initialization
    void Start () {
        BattleRating = Random.Range(50, 1000);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
