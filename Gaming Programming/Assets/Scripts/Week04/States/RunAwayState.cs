using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayState : State {
    public RunAwayState()
    {
        actions = new Action[1];
        actions[0] = new EvadeAction();
        transitions = new Transition[1];
        transitions[0].decision = new SafeDecision();
        transitions[0].trueState = new PatrolState();
        transitions[0].falseState = this;
    }
}
