using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float BattleRating;
    float size = 0f;
    // Use this for initialization
    void Start () {
        BattleRating = Random.Range(50, 1000);
        size = (BattleRating / 100f);
        if (size >= 1)
        {
            size = 1;
            Debug.Log("Too Small");
        }
        transform.localScale += new Vector3(size, size, size);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
