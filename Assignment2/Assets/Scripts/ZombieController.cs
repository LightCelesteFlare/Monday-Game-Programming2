using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {
    public GameObject player;
    private float power = 0.6f;    
    // Next Var need to implement Safe [and Threatened]
    public float SafeDistanceCutoff = 5f;
    NavMeshAgent agent;
    
    // Threatened
    public float TreatDistanceCutoff = 5f;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            Debug.Log("Make sure your player is tagged!!");
        }

    }
	
	// Update is called once per frame
	void Update () {
        Condition();
    }

    private void Condition()
    {

            //if ((player.transform.position - transform.position).sqrMagnitude < Mathf.Pow(agent.stoppingDistance, 2)) {
            if (StrongerThanEnemy())
            {
                agent.destination = player.transform.position;
                // If the agent is in attack range, become an obstacle and
                // disable the NavMeshAgent component
                
                agent.enabled = true;
            }

        else
        {
            if (Safe()) { 
            agent.enabled = false;
            agent.enabled = true;
            agent.destination = -(player.transform.position);
            }
        }

    }
    bool StrongerThanEnemy()
    {
        return power > player.GetComponent<PlayerController>().Power;
    }

    bool WeakerThanEnemy()
    {
        return !StrongerThanEnemy();
    }

    bool Safe()
    {
        Vector3 E2T = transform.position - player.transform.position;
        float dTE = E2T.magnitude;                                      //Distance
        return dTE > SafeDistanceCutoff;
    }
}
