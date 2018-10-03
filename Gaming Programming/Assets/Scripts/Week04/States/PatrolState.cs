using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State {
    public PatrolState()
    {
        actions = new Action[1];
        actions[0] = new FollowPatrolAction();

        // if you are stronger than the enemy
        transitions = new Transition[2];
        transitions[0].decision = new ThreatenedStrongerThanEnemyDecision();
        transitions[0].trueState = new AttackState();
        transitions[0].falseState = new RunAwayState();

        // if you are weaker than the enemy
        transitions[1].decision = new ThreatenedWeakerThanEnemyDecision();
        transitions[1].trueState = new RunAwayState();
        transitions[1].falseState = new AttackState();
    }
}
