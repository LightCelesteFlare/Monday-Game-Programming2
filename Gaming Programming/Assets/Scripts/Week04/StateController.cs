using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StateController : MonoBehaviour {

    public State currentState;
    public State remainState;
    EnemyProperties enemyStats;

    public GameObject enemy;

    // Waypoint GameObject
    public GameObject[] Waypoints;

    // Set Waypoint markers
    public int currentWaypoint = 0;
    public int nextWaypoint;
    public float speed = 1f; // meter/sec

    // Next Var need to implement Safe [and Threatened]
    public float SafeDistanceCutoff = 5f;

    // Threatened
    public float TreatDistanceCutoff = 2f;

    // Next Var need to implement StrongerThanEnemy [and WeakerThanEnemy]
    public float strength = 100;
    // 
    // Waypoint
    public int CalculateNextWaypoint()
    {
        return (currentWaypoint + 1) % Waypoints.Length;
    }

    public void Start()
    {
        
    }
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        //if (currentState != null && eyes != null)
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            //Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }
    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            //OnExitState();
        }
    }
}
