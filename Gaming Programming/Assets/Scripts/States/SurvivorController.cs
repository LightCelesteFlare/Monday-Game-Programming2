using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorController : MonoBehaviour {

    public GameObject Survivor;

    // Condition State
    public enum SurvivorState { RunAway, Patrol, Attack };
    public SurvivorState currentState;

    // Waypoints (future feature)
    public GameObject[] Points;

    //Strength
    public float BattleRating = 0f;

    // Stats
    public float health;
    public float attack;
    public float armor;
    // movement
    public float speed = 1f;

    // Use this for initialization
    void Start () {
		health = Random.Range(100, 140)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
