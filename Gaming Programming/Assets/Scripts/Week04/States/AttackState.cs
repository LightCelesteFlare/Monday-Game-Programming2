using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State {
    public AttackState()
    {
        actions = new Action[1];
        actions[0] = new AttackEnemyAction();
        transitions = new Transition[1];
        transitions[0].decision = new WeakerThanEnemyDecision();
        transitions[0].trueState = new RunAwayState();
        transitions[0].falseState = this;
    }
}
