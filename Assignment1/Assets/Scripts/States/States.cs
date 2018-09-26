using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classwork sept 12 2018
// week 2 and 3
// class:396

public class States : MonoBehaviour {

    public enum TrollState { RunAway, Patrol, Attack };
    public TrollState currentState;
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
    // 
    int CalculateNextWaypoint()
    {
        return (currentWaypoint + 1) % Waypoints.Length;
    }


	// Use this for initialization
	void Start () {
        currentState = TrollState.Patrol;
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        nextWaypoint = CalculateNextWaypoint();
        transform.position = Waypoints[currentWaypoint].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateState();
	}
    //Transitions
    void EvadeEnemy()
    {
        Vector3 p0 = transform.position;
        Vector3 p1 = enemy.transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p0 - p1).normalized;
        //newPos.y = 0.5f;
        transform.position = newPos;
        print("In Troll.EvadeEnemy");
    }

    void ChangeState(TrollState toState)
    {
        currentState = toState;
    }

    void FollowPatrolPath()
    {
        nextWaypoint = CalculateNextWaypoint();
        //Vector3 p0 = Waypoints[currentWaypoint].transform.position;
        Vector3 p0 = transform.position;
        Vector3 p1 = Waypoints[nextWaypoint].transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p1 - p0).normalized;
        transform.position = newPos;
        if((newPos - p1).magnitude < .5)
        {
            currentWaypoint = nextWaypoint;
        }

        print("In Troll.FollowPatrolPath");
    }

    void BashEnemyOverHead()
    {
        print("In Troll.BashEnemyOverHead");
    }
    // Conditions
    bool Safe()
    {
        Vector3 E2T = transform.position - enemy.transform.position;
        float dTE = E2T.magnitude;                                      //Distance
        return dTE > SafeDistanceCutoff;
    }

    bool Threatened()
    {
        Vector3 E2T = transform.position - enemy.transform.position;
        float dTE = E2T.magnitude;
        return dTE < TreatDistanceCutoff ;
    }
    bool StrongerThanEnemy()
    {
        return strength > enemy.GetComponent<EnemyController>().BattleRating;
    }

    bool WeakerThanEnemy()
    {
        return !StrongerThanEnemy();
    }

    int FindIndexOfClosesWaypoint(Vector3 pos)
    {
        int idx = 1;
        float dist = 1e10f;
        for (int i = 0; i < Waypoints.Length; i++)
        {
            float dist_i = Vector3.Distance(pos, Waypoints[i].transform.position);
            if (dist_i < dist)
            {
                dist = dist_i;
                idx = i;
            }
        }
        return idx;
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case TrollState.RunAway:

                EvadeEnemy();

                if (Safe())
                {

                    ChangeState(TrollState.Patrol);
                }

                break;
            case TrollState.Patrol:

                FollowPatrolPath();

                if (Threatened())
                {
                    if (StrongerThanEnemy())
                    {
                        ChangeState(TrollState.Attack);
                    }
                    else
                    {
                        ChangeState(TrollState.RunAway);
                    }
                }

                break;

            case TrollState.Attack:

                if (WeakerThanEnemy())
                {
                    ChangeState(TrollState.RunAway);
                }

                else
                {
                    BashEnemyOverHead();
                }

                break;

        }//end switch

    }
}
