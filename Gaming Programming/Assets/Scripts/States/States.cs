using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classwork sept 12 2018 
// class:396

public class States : MonoBehaviour {

    public enum TrollState { RunAway, Patrol, Attack };
    public TrollState currentState;
    public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateState();
	}
    //Transitions
    void EvadeEnemy()
    {
        print("In Troll.EvadeEnemy");
    }

    void ChangeState(TrollState toState)
    {
        currentState = toState;
    }

    void FollowPatrolPath()
    {
        print("In Troll.FollowPatrolPath");
    }

    void BashEnemyOverHead()
    {
        print("In Troll.BashEnemyOverHead");
    }
    // Conditions
    bool Safe()
    {
        return true;
    }

    bool Threatened()
    {
        return false;
    }
    bool StrongerThanEnemy()
    {
        return false;
    }

    bool WeakerThanEnemy()
    {
        return !StrongerThanEnemy();
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
