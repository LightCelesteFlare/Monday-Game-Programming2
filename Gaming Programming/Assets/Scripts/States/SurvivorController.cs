using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SurvivorController : MonoBehaviour { 

    public GameObject Survivor;
    public GameObject Enemy;
    public LevelVersion2 level;
    public ManageConfig conf;
    // Condition State
    public enum SurvivorState { RunAway, Patrol, Attack, Wander}; //Patrol is disabled
    public SurvivorState currentState;

    // Waypoints (future feature)
    private GameObject[] Points;

    // Next Var need to implement Safe [and Threatened]
    public float SafeDistanceCutoff = 5f;

    // Threatened
    public float TreatDistanceCutoff = 2f;

    // Rotation speed
    public float Rotspeed = 100f;
    // Bool for the wandering
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    /*
    // Waypoint
    int CalculateNextWaypoint()
    {
        return (currentWaypoint + 1) % Waypoints.Length;
    }
    */

    // Stats
    public float health;
    public float attack;
    public float armor;
    // movement
    public float speed = 1f;

    //Strength
    public float BattleRating = 0f;

    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.2f, 1f);
        health = Random.Range(100, 140);
        attack = Random.Range(3, 12);
        armor = Random.Range(0, 4);
        speed += Random.Range(1, 2);
        BattleRating = ((health / 2) + ((armor + attack) * 2));
	}
	
	// Update is called once per frame
	void Update () {
        UpdateState();	
	}

    //Transitions
    void EvadeEnemy()
    {
        Vector3 p0 = transform.position;
        Vector3 p1 = Enemy.transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p0 - p1).normalized;
        //newPos.y = 0.5f;
        transform.position = newPos;
        print("In Survivor.EvadeEnemy");
    }

    void ChangeState(SurvivorState toState)
    {
        currentState = toState;
    }
    /*
    void FollowPatrolPath()
    {
        nextWaypoint = CalculateNextWaypoint();
        //Vector3 p0 = Waypoints[currentWaypoint].transform.position;
        Vector3 p0 = transform.position;
        Vector3 p1 = Waypoints[nextWaypoint].transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p1 - p0).normalized;
        transform.position = newPos;
        if ((newPos - p1).magnitude < .5)
        {
            currentWaypoint = nextWaypoint;
        }

        print("In Troll.FollowPatrolPath");
    }
    */
    void AttackEnemy()
    {
        Vector3 p0 = transform.position;
        Vector3 p1 = Enemy.transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p1 - p0).normalized;
        //newPos.y = 0.5f;
        transform.position = newPos;
        print("In Survivor.Attack");
    }
    // Party/Grouping

    // TRGameDev
    void Wandering()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * Rotspeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -Rotspeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
    }

    // 0 - nothing | 1 - right | 2 - left
    IEnumerator Wander()
    {
        // TRGameDev
        int rotTime = Random.Range(1, 3);       // amount of time it rotates
        int rotateWait = Random.Range(1, 3);    // wait for the rotate cycle
        int rotateLorR = Random.Range(0, 3);    // decide if it want to do right or left (bool)
        int walkWait = Random.Range(1, 3);      // walk wait - is the time between walking
        int walkTime = Random.Range(1, 5);      // will be walking

        isWandering = true;                     
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }

    // Conditions
    bool Safe()
    {
        Vector3 E2T = transform.position - Enemy.transform.position;
        float dTE = E2T.magnitude;                                      //Distance
        return dTE > SafeDistanceCutoff;
    }

    bool ThreatLevel()
    {
        Vector3 E2T = transform.position - Enemy.transform.position;
        float dTE = E2T.magnitude;
        return dTE < TreatDistanceCutoff;
    }

    bool StrongerThanEnemy()
    {
        return BattleRating < Enemy.GetComponent<EnemyController>().BattleRating;
    }

    bool WeakerThanEnemy()
    {
        return !StrongerThanEnemy();
    }

    bool Target()
    {
        if (GameObject.FindGameObjectWithTag("Survivor") || GameObject.FindGameObjectWithTag("Player"))
        {
            return false;
        }
        else
            return true;
    }

    void UpdateState()
    {
        switch (currentState)
        {
            // Runaway
            case SurvivorState.RunAway:

                EvadeEnemy();

                if (Safe())
                {
                    ChangeState(SurvivorState.Wander);
                }

                break;
            /*
                // Patrol
                case SurvivorState.Patrol:

                FollowPatrolPath();

                if (ThreatLevel())
                {
                    if (StrongerThanEnemy())
                    {
                        ChangeState(SurvivorState.Attack);
                    }
                    else
                    {
                        ChangeState(SurvivorState.RunAway);
                    }
                }

                break;
                */
            case SurvivorState.Wander:
                Wandering();
                    if (ThreatLevel())
                    {
                        if (StrongerThanEnemy())
                        {
                            ChangeState(SurvivorState.Attack);
                        }
                        if (WeakerThanEnemy())
                        {
                            ChangeState(SurvivorState.RunAway);
                        }

                }
                //if (!Target())
                //{ 
                //    ChangeState(SurvivorState.Group);
                //}
                break;

            case SurvivorState.Attack:

                if (WeakerThanEnemy())
                {
                    ChangeState(SurvivorState.RunAway);
                    Debug.Log("I'm Running in S.Attack");
                }

                else
                {
                    AttackEnemy();

                    if (Safe())
                    {
                        ChangeState(SurvivorState.Wander);
                    }
                    Debug.Log("I'm Attacking in S.Attack");
                }

                break;
            //case SurvivorState.Group:
            //    Party();
            //    Debug.Log("SurvivorState.Group");
            //    ChangeState(SurvivorState.Wander);
            //    break;

        }//end switch
    }   // end UpdateState
}





/*
 * TRGameDev - https://www.youtube.com/watch?v=aEPSuGlcTUQ
 */
